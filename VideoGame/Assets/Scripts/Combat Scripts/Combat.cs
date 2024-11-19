using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This script handles combat. Locks the 
 * enemy and player in a certain spot and turns on Combat UI
 * 
 */

public class Combat : MonoBehaviour
{
    private MovementScript movement;// Grab the movement component of the player

    private EnemyScript[] enemy;// Grab a list of all enemies
    private Vector2 enemyFightPos; // This is the fighting position the enemy will assume

    private PlayerScript player;// This grabs the player script
    private Vector2 playerFightPos;// This is the fighting position for the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None); // Find all enemies
        enemyFightPos = new Vector2(2,0); // Initialize enemy fighting position

        movement = FindAnyObjectByType<MovementScript>();// Grab the movement script of the player

        player = FindAnyObjectByType<PlayerScript>();// Grab the player
        playerFightPos = new Vector2(-2, 0);// Initialize player fighting position
    }

    // Update is called once per frame
    void Update()
    {
        foreach (EnemyScript badGuy in enemy)// Iterate through all enemies
        {

            if (badGuy.FightCheck == true && player.FightCheck == true)// If both enemy and player are in combat, do this:
            {
                movement.enabled = false; // Disable movement

                // Set the positions of enemy and player
                badGuy.transform.position = enemyFightPos;

                player.transform.position = playerFightPos;

                // After all of this the AttackButton and RunButton scripts take care of the rest of combat

            }

        }


    }
}
