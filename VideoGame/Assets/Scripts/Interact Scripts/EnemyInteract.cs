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
    private bool fightCheck; // This holds the fightCheck from Combat Script

    // Public Static variables
    public static double health; // The health stat of the enemy
    public static double attack; // The attack stat of the enemy

    public static double posX; // The x position of the enemy. Used to calculate distance in CombatScript
    public static double posY;// The x position of the enemy. Used to calculate distance in CombatScript

    public static float fightPosX; // This is the x position the player will take when in combat
    public static float fightPosY; // This is the y position the player will take when in combat

    //Initiate fightCheck, fightPos, health, and Attack
    void Start()
    {
        fightCheck = CombatScript.fightCheck;

        fightPosX = 2f; fightPosY = 0f;

        health = 20;

        attack = 1;

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
            transform.position = new Vector2(fightPosX , fightPosY);
        }
    }
}