using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: The purpose of this script is to keep track of the players position, as well as attack and health.
 * When combat initiates, this script reports the fighting position of the player.
 */


public class PlayerInteract : MonoBehaviour
{
    // Private Variables
<<<<<<< HEAD
    private bool fightCheck; // This holds the fightCheck from Combat Script

    // Public Static variables
    public static double health; // The health stat of the player
    public static double attack; // The attack stat of the player

    public static double posX; // The x position of the player. Used to calculate distance in CombatScript
    public static double posY;// The y position of the player. Used to calculate distance in CombatScript

    public static float fightPosX; // This is the x position the player will take when in combat
    public static float fightPosY; // This is the y position the player will take when in combat
=======
    private Vector2 fightPos; // This is the position the player will take when in combat
    private bool fightCheck; // This holds the fightCheck from Combat Script

    // Public Static variables
    public static double health = 20; // The health stat of the player
    public static double attack = 5; // The attack stat of the player
    public static double defense = 5; // Def stat of the player
    public static double speed = 5; // Speed stat of player
    public static int exp = 0; // XP of the player
    public static int level = 1; // Level of the player
    public static int statPoint = 0; // stat points that will go into other stats

    public static double posX; // The x position of the player. Used to calculate distance in CombatScript
    public static double posY;// The x position of the player. Used to calculate distance in CombatScript
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

    //Initiate fightCheck, fightPos, health, and Attack
    void Start()
    {
        fightCheck = CombatScript.fightCheck;

<<<<<<< HEAD
        fightPosX = -2f; fightPosY = 0f;

        health = 20;

        attack = 5;
=======
        fightPos = new Vector2(-2, 0);
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

    }


    // Check to see if player is in combat. If not, update position for CombatScript. If so, assume fighting position
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
            transform.position = new Vector2(fightPosX,fightPosY);
=======
            transform.position = fightPos;
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
        }
    }
}