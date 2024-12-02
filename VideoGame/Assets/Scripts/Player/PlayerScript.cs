using UnityEngine;
using System.Collections.Generic;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This script holds the stats for the player.
 *  This script also keeps track of distances between all enemies in the map and initiates combat by pressing "E"
 *  Once combat is initated, this script passes information to the Combat script
 * 
 */

public class PlayerScript : MonoBehaviour
{
    private EnemyScript[] enemy; //The list to keep track of all enemies
    private Vector2 distance;// This variable keeps track of distance between all enemies

    public bool FightCheck { get; set; } // This keeps track of whether the player is in combat or not

    public double Health { get;  set; } // The health of the player
    public double Attack { get; private set; }// The attack of the player
    public double Mana { get; set; } //The mana of the player.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Grab all objects with the enemy script and put them in an array
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        FightCheck = false;// Start the fight check at false

        // Initialize the player stats
        Attack = 5;
        Health = 20;
        Mana = 20;
    }

    // Update is called once per frame
    void Update()
    {

        foreach (EnemyScript badGuy in enemy) // A for loop that iterates through all enemies
        {
            // Find the distance between all enemies and player
            distance = badGuy.transform.position - transform.position;

            if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E)) // If very close and the player press "E" to initiate combat, switch fight check
            {
                // We're in combat now. Visit combat script to see how combat works.
                FightCheck = true;

            }

        }

        
    }
}
