using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 12/7/2024
 * Last Updated by: Ashton Williams
 * Update log: 
 * - Copied and edited for use as a skill!
 * Description: This script functions as a special attack only able to be used if the player
 * has the resources to. If they don't, a message will be displayed in the console.
 * This one has no unique in-battle effects.
 * It does, however, still mediate damage between the player and enemy, while
 * also checking on the health of the player and enemy and deciding the victor.
 */

public class SlashSkill : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component

    private MovementScript movement;// Variable for the movement of the player

    public PlayerScript player;// Variable to find player

    private EnemyScript[] enemy;// Variable for all enemies

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
    public void slash()
    {
        foreach (EnemyScript badGuy in enemy)// Iterate through all enemies
        {
            if (badGuy.FightCheck == true && player.FightCheck == true)// Make sure the enemy is in combat
            {
                if (player.Mana<5)
                {
                    Debug.Log("Not enough mana, dude");
                }
                else
                {
                    if (player.speed >= badGuy.speed) // if player's speed is greater or equal to enemy's, player attacks first
                    {
                        DefCheck defCheck = new DefCheck();
                        double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction
                        double enemydefReduction = defCheck.DamageReduction(badGuy.defense); // does the same for the enemy

                        player.Mana -= 5; //depletes mana.
                        badGuy.Health = DmgCalc.PlayerAttack(player.Attack * 1.2, enemydefReduction, badGuy.Health); // player attacks first
                        if (badGuy.Health<=0) //quickly checks enemy's health to see if they are still alive.
                        {
                            Debug.Log("You win!"); //message for debug purposes stating that we win. Battle should
                                //end after this.
                        }
                        else
                        {
                            player.Health = DmgCalc.EnemyAttack(badGuy.Attack, playerdefReduction, player.Health); // enemy attacks second
                            //later code will determine what happens after.

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
                            Debug.Log("You lose.."); //same deal as before, if we're dead we can't hit back.
                            //battle will end after this message displays.
                        }
                        else
                        {
                            player.Mana -= 5; //depletes mana for skill usage.
                            badGuy.Health = DmgCalc.PlayerAttack(player.Attack * 1.2, enemydefReduction, badGuy.Health); // player attacks second
                        }
                    }
                }


                //Ends combat, but will only give exp if enemy hits zero health.
                if (player.Health <= 0)
                {
                    // Exit combat
                    player.FightCheck = false;
                    badGuy.FightCheck = false;
                    movement.enabled = true;

                }

                else if (badGuy.Health <= 0)
                {
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