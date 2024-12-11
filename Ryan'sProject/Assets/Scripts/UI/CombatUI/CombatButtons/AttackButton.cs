using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/27/2024
 * Last Updated by: Ryan Tran
 * Update log: 
 * - Removed comments for damage (11/27/2024)
 * Description: The purpose of this script is to mediate damage between the player and enemy.
 * Also checks on the health of the player and enemy and decides the victor
 */

public class AttackButton : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component

    private MovementScript movement;// Variable for the movement of the player

    public PlayerScript player;// Variable to find player

    private EnemyScript[] enemy;// Variable for all enemies

    private GameOverScreen gameOver; // Variable for the game over screen

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
        gameOver = GameObject.Find("GameOverCanvas").GetComponent< GameOverScreen>();

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
    public void attack()
    {
        foreach (EnemyScript badGuy in enemy)// Iterate through all enemies
        {
            if (badGuy.FightCheck == true && player.FightCheck == true)// Make sure the enemy is in combat
            {
                if (player.speed >= badGuy.speed) // if player's speed is greater or equal to enemy's, player attacks first
                {
                    DefCheck defCheck = new DefCheck();

                    double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction
                    double enemydefReduction = defCheck.DamageReduction(badGuy.defense); // does the same for the enemy

                    badGuy.Health = DmgCalc.PlayerAttack(player.Attack, enemydefReduction, badGuy.Health); // player attacks first

                    if (badGuy.Health <= 0)
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

                    player.Health = DmgCalc.EnemyAttack(badGuy.Attack, playerdefReduction, player.Health); // enemy attacks second

                    //Check whose health is 0
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
                else // If enemy speed is greater than player's, enenmy attacks first
                {
                    DefCheck defCheck = new DefCheck();
                    double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction
                    double enemydefReduction = defCheck.DamageReduction(badGuy.defense); // does the same for the enemy

                    player.Health = DmgCalc.EnemyAttack(badGuy.Attack, playerdefReduction, player.Health); // enemy attacks first

                    //Check whose health is 0
                    if (player.Health <= 0)
                    {
                        // Exit combat
                        player.FightCheck = false;
                        badGuy.FightCheck = false;
                        movement.enabled = true;

                        // Declare game over
                        gameOver.Setup();
                    }

                    badGuy.Health = DmgCalc.PlayerAttack(player.Attack, enemydefReduction, badGuy.Health); // player attacks second

                    if (badGuy.Health <= 0)
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

}