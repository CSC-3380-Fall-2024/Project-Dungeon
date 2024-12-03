using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/22/2024
 * Description: This is the script that allows items to be collected
 * For now, all this script does is send a message on console and destory
 * the item gameobject
 * 
 */

public class ItemScript : MonoBehaviour
{
   // private bool collected; // Keep track if item is collected or not
    private PlayerScript player; //Keep track of player
    private Vector2 distance; // Keep track of distance between item and player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize collected
        //collected = false;

        // Find player
        player = FindAnyObjectByType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        distance = player.transform.position - transform.position;

        if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E)) // If very close and the player press "E", print a statement
        {
            Debug.Log("Item interacted");
            //collected = true;
            Destroy(this.gameObject);

        }

    }
}
