using UnityEngine;
using System;
/*
 *Author: Ryan Tin Tran
 *Last Updated: 11/7/2024
 *Description: The purpose of this script is to keep track off the distance between the player and .
 *When the player presses 'E' and is close enough, combat will initiate and let other scripts know.
 */



public class CombatScript : MonoBehaviour
{
    // Public Static Variables
    public static double distance; // This is to find the distance between player and 
    public static bool fightCheck; // This keeps track off whether we're in a fight or not
    public static MovementScript movement; // This is the movement script we need to turn off when in a fight

    // The features the object starts off with
    void Start()
    {

        fightCheck = false;
        movement = GetComponent<MovementScript>();  

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Non-combat if statements
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

        // Update the distance between the player and  in non-combat
        if (fightCheck == false)
        {
            distance = Math.Sqrt(Math.Pow(PlayerInteract.posX - EnemyInteract.posX, 2) 
                + Math.Pow(PlayerInteract.posY - EnemyInteract.posY, 2));
        
        }
        
        // This is how we initiate combat
        if (fightCheck == false && Input.GetKeyUp(KeyCode.E) && distance < 1)
        {
            fightCheck = true;

            movement.enabled = false;
<<<<<<< HEAD
=======

            Debug.Log("Engage Combat");
            Debug.Log("Player health: " + PlayerInteract.health);
            DefCheck defCheck = new DefCheck();
            double defReduction = defCheck.DamageReduction(PlayerInteract.defense);
            defReduction = (1 - defReduction)*100;
            Debug.Log("Player has " + defReduction + "% Damage Reduction");
            Debug.Log(" health: " + EnemyInteract.health);
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
        }

        
    }
}
