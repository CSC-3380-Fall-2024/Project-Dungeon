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

    public double Health { get;  set; }// health stat for the enemy
    public double Attack { get; private set; }// Attack stat for enemy

<<<<<<< HEAD
    //[SerializeField]
    public Vector2 OriginalPosition { get; private set; }

=======
>>>>>>> main
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find position of the player
        player = FindAnyObjectByType<PlayerScript>().transform;

        //Initialize stats and fight check
        FightCheck = false;

        Attack = 1;
        Health = 20;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Health <= 0)
        {

            Destroy(this.gameObject);
        
        }

=======
>>>>>>> main
        //Calculate distance between itself and player
        distance = player.position - transform.position;

        if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E))// Check to see if player is close enough and interacts
        {
<<<<<<< HEAD
            //Grab original positon
            OriginalPosition = transform.localPosition;

=======
>>>>>>> main
            // We're in combat. Check Combat script to follow the flow
            FightCheck = true;

        }
    }
}
