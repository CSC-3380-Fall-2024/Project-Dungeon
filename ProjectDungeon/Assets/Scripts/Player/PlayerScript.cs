using UnityEngine;
using System.Collections.Generic;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 12/7/2024
 * Description: This script holds the stats for the player.
 *  This script also keeps track of distances between all enemies in the map and initiates combat by pressing "E"
 *  Once combat is initated, this script passes information to the Combat script
 * 
 *Update log:
 * 12/7/2024: Added Max heatlh
 * 
 */

public class PlayerScript : MonoBehaviour
{
    private EnemyScript[] enemy; //The list to keep track of all enemies
    private Vector2 distance;// This variable keeps track of distance between all enemies
    public Vector2 OriginalPosition { get; private set; } // This is the player's position before he enters combat

    private Combat combat; // Grab the combat script

    public bool FightCheck { get; set; } // This keeps track of whether the player is in combat or not

    public double Health { get;  set; } // The health of the player
    public double MaxHealth { get; set; } //MaxHp of the player
    public double Attack { get;  set; }// The attack of the player
    public double defense { get; set; } // Def stat of the player
    public double speed { get; set; } // Speed stat of player
    public int exp { get; set; } // XP of the player
    public int Mana { get; set; } //  mana the player has
    public int MaxMana { get; set; } // max mana the player has
    public int level { get; set; } // Level of the player
    public int statPoint { get; set; } // stat points that will go into other stats

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Grab all objects with the enemy script and put them in an array
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        // Find combat script
        combat = GameObject.Find("Combat").GetComponent<Combat>();

        FightCheck = false;// Start the fight check at false

        // Initialize the player stats
        Attack = 5;
        Health = 20;
        MaxHealth = 20;
        defense = 1;
        speed = 5;
        exp = 0;
        Mana = 20;
        MaxMana = 20;
        level = 1;
        statPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update enemy list
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        foreach (EnemyScript badGuy in enemy) // A for loop that iterates through all enemies
        {
            // Find the distance between all enemies and player
            distance = badGuy.transform.position - transform.position;

            if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E)) // If very close and the player press "E" to initiate combat, switch fight check
            {
                //Grab original positon
                OriginalPosition = transform.localPosition;

                // We're in combat now. Visit combat script to see how combat works.
                FightCheck = true;
                combat.startCombat();

            }

        }

        
    }
}
