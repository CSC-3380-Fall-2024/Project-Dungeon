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
    private Vector2 fightPos; // This is the position the enemy will take when in combat
    private bool fightCheck; // This holds the fightCheck from Combat Script

    // Public Static variables
    public static double health = 20; // The health stat of the enemy
    public static double attack = 1; // The attack stat of the enemy
    public static double defense = 1; // Def stat of the enemy
    public static double speed = 3; // Speed stat of enemy

    public static double posX; // The x position of the enemy. Used to calculate distance in CombatScript
    public static double posY;// The x position of the enemy. Used to calculate distance in CombatScript

    //Initiate fightCheck, fightPos, health, and Attack
    void Start()
    {
        fightCheck = CombatScript.fightCheck;

        fightPos = new Vector2(2, 0);

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
            transform.position = fightPos;
        }
    }
}