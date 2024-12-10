using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This script holds the stats for the enemy.
 *  This script also keeps track of distance between the player and 
 *  sees if the player presses "E" to initiate combat
 *  Once combat is initated, this script passes information to the Combat script
 * 
 */

public class EnemyScript : MonoBehaviour
{
    private Transform player;// Variable to hold the player
    private Vector2 distance;// Keep track of distance between itself and player

    public bool FightCheck { get; set; }// Hold status for whether we're in combat or not
    public Vector2 OriginalPosition { get; private set; }

    public double Health { get;  set; }// health stat for the enemy

    public double defense { get; set; } // Def stat of the enemy
    public double speed { get; set; } // Speed stat of enemy
    public int dropExp { get; set; } // amount of exp enemy will drop once defeated

    [SerializeField]
    public double Attack;// Attack stat for enemy
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find position of the player
        player = FindAnyObjectByType<PlayerScript>().transform;

        //Initialize stats and fight check
        FightCheck = false;

        //Attack = 1; // We're uninitializing this for now. I plan for the boss and enemy to share same script
        Health = 20;
        defense = 3;
        speed = 3;
        dropExp = 21;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy enemy if health is 0
        if (Health <= 0)
        {Destroy(this.gameObject);}

        //Calculate distance between itself and player
        distance = player.position - transform.position;

        if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E))// Check to see if player is close enough and interacts
        {
            //Grab original positon
            OriginalPosition = transform.localPosition;

            // We're in combat. Check Combat script to follow the flow
            FightCheck = true;

        }
    }
}
