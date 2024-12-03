using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: The purpose of this script is to keep track of the  position, as well as attack and health.
 * When combat initiates, this script reports the fighting position of the .
 */

public class EnemyInteract : MonoBehaviour
{
    // Private Variables
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
    private bool fightCheck; // This holds the fightCheck from Combat Script

    // Public Static variables
    public static double health; // The health stat of the enemy
    public static double attack; // The attack stat of the enemy
=======
>>>>>>> main
>>>>>>> main
    private Vector2 fightPos; // This is the position the enemy will take when in combat
    private bool fightCheck; // This holds the fightCheck from Combat Script

    // Public Static variables
    public static double health = 20; // The health stat of the enemy
    public static double attack = 1; // The attack stat of the enemy
<<<<<<< HEAD
<<<<<<< HEAD
    public static double defense = 0; // Def stat of the enemy
    public static double speed = 3; // Speed stat of enemy
    public static int dropExp = 35; // Amount of XP that an enemy will drop
=======
    public static double defense = 20; // Def stat of the enemy
    public static double speed = 3; // Speed stat of enemy
>>>>>>> f0b4c86ff1ffcadcdcf16aa7b94913ff608f2c59
=======
<<<<<<< HEAD
    public static double defense = 1; // Def stat of the enemy
    public static double speed = 3; // Speed stat of enemy
=======
    public static double defense = 0; // Def stat of the enemy
    public static double speed = 3; // Speed stat of enemy
    public static int dropExp = 35; // Amount of XP that an enemy will drop
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main

    public static double posX; // The x position of the enemy. Used to calculate distance in CombatScript
    public static double posY;// The x position of the enemy. Used to calculate distance in CombatScript

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
    public static float fightPosX; // This is the x position the player will take when in combat
    public static float fightPosY; // This is the y position the player will take when in combat

=======
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main
    //Initiate fightCheck, fightPos, health, and Attack
    void Start()
    {
        fightCheck = CombatScript.fightCheck;

<<<<<<< HEAD
        fightPos = new Vector2(2, 0);
=======
<<<<<<< HEAD
        fightPos = new Vector2(2, 0);
=======
<<<<<<< HEAD
        fightPosX = 2f; fightPosY = 0f;

        health = 20;

        attack = 1;
=======
        fightPos = new Vector2(2, 0);
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main

    }


    // Check to see if enemy is in combat. If not, update position for CombatScript. If so, assume fighting position
    void FixedUpdate()
    {
        fightCheck = CombatScript.fightCheck;

        if (fightCheck == false)
        {
            posX = transform.position.x;
            posY = transform.position.y;
        }
        else if (fightCheck == true)
        {
<<<<<<< HEAD
            transform.position = fightPos;
=======
<<<<<<< HEAD
            transform.position = fightPos;
=======
<<<<<<< HEAD
            transform.position = new Vector2(fightPosX , fightPosY);
=======
            transform.position = fightPos;
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main
        }
    }
}