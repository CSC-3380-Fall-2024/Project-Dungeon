using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 12/10/2024
 * Last Updated by: Ashton Williams
 * Update log: 
 * - Copied and edited for a different skill!
 * Description: This script functions as a special attack only able to be used if the player
 * has the resources to. If they don't, a message will be displayed in the console.
 * This one acts like a gamble, if you get lucky the enemy will instantly die! Nothing happens otherwise.
 * It does, however, still mediate damage between the player and enemy, while
 * also checking on the health of the player and enemy and deciding the victor.
 */

public class ThunderboltSkill : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component

    private MovementScript movement;// Variable for the movement of the player

    public PlayerScript player;// Variable to find player

    private EnemyScript[] enemy;// Variable for all enemies
    public int randNum { get; set; }//random number, needed every time spell is called.

    private GameOverScreen gameOver; // Variable for the game over screen

    private TextBubbleManager textBubble; // Keep track of text bubble


    // Initiate and disable the Button and Image components
    void Awake()
    {
        // Find player and all enemies
        player = FindAnyObjectByType<PlayerScript>();
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        //Find the button for the attack button
        myButton = GetComponent<Button>();
        myButton.enabled = player.FightCheck;

        //Find the image for the attack button
        myImage = GetComponent<Image>();
        myImage.enabled = player.FightCheck;

        //Find the movement script for the player
        movement = FindAnyObjectByType<MovementScript>();

        // Find the game over canvas
        gameOver = GameObject.Find("GameOverCanvas").GetComponent<GameOverScreen>();

        // Find text bubble canvas
        textBubble = GameObject.Find("TextBubbleCanvas").GetComponent<TextBubbleManager>();

    }

    // Update to see if the Button and Image component needs to be enabled
    void Update()
    {
        // Update list of enemies
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        // The buttons and image is enabled depending if the player is in combat or not
        myButton.enabled = player.FightCheck;

        myImage.enabled = player.FightCheck;

    }

    // Function that activates everytime the attack button is clicked. Player and enemy fights
    // Assumes the Player moves first
    public void bolt()
    {
        foreach (EnemyScript badGuy in enemy)// Iterate through all enemies
        {
            randNum = Random.Range(0, 11);
            if (badGuy.FightCheck == true && player.FightCheck == true)// Make sure the enemy is in combat
            {
                if (player.Mana<player.MaxMana)
                {
                    string text = "Not enough mana...";
                    textBubble.turnON(text);
                }
                else
                {
                    if (player.speed >= badGuy.speed) // if player's speed is greater or equal to enemy's, player attacks first
                    {
                        DefCheck defCheck = new DefCheck();
                        double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction
                        double enemydefReduction = defCheck.DamageReduction(badGuy.defense); // does the same for the enemy
                        player.Mana -= player.Mana; //depletes mana
                        if (randNum<=1) //checks the random number generated earlier. If you're within specified range, enemy dies.
                        {

                            badGuy.Health = 0;

                            // Exit combat
                            player.FightCheck = false;
                            badGuy.FightCheck = false;

                            //Enable movement
                            movement.enabled = true;

                            // Player is returned to original position
                            player.transform.localPosition = player.OriginalPosition;

                            LvlUp expCheck = FindFirstObjectByType<LvlUp>();
                            if (expCheck != null)
                            {
                                player.exp = expCheck.xpCheck(player.exp, badGuy.dropExp); // after enemy is defeated, gives player xp
                            }
                            else
                            {
                                Debug.LogError("LvlUp component not found brah");
                            }
                        }
                        else
                        {

                            player.Health = DmgCalc.EnemyAttack(badGuy.Attack * 2, playerdefReduction, player.Health); // enemy attacks second
                            if (player.Health <= 0)
                            {
                                // Exit combat
                                player.FightCheck = false;
                                badGuy.FightCheck = false;
                                movement.enabled = true;

                                // Declare game over
                                gameOver.Setup();
                            }

                        }

                    }
                    else // If enemy speed is greater than player's, enenmy attacks first
                    {
                        DefCheck defCheck = new DefCheck();
                        double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction
                        double enemydefReduction = defCheck.DamageReduction(badGuy.defense); // does the same for the enemy

                        player.Health = DmgCalc.EnemyAttack(badGuy.Attack, playerdefReduction, player.Health); // enemy attacks first
                        if (player.Health<=0)
                        {
                            // Exit combat
                            player.FightCheck = false;
                            badGuy.FightCheck = false;
                            movement.enabled = true;

                            // Declare game over
                            gameOver.Setup();
                        }
                        else
                        {
                            player.Mana -= player.Mana; //depletes mana for skill usage.
                            if (randNum <= 1)
                            {
                                badGuy.Health = 0;

                                // Exit combat
                                player.FightCheck = false;
                                badGuy.FightCheck = false;

                                //Enable movement
                                movement.enabled = true;

                                // Player is returned to original position
                                player.transform.localPosition = player.OriginalPosition;

                                LvlUp expCheck = FindFirstObjectByType<LvlUp>();
                                if (expCheck != null)
                                {
                                    player.exp = expCheck.xpCheck(player.exp, badGuy.dropExp); // after enemy is defeated, gives player xp
                                }
                                else
                                {
                                    Debug.LogError("LvlUp component not found brah");
                                }

                            }
                        }
                    }
                }

            }
            

        }

    }

}