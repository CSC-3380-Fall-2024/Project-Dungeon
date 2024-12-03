using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/22/2024
 * Description: This is the UI to indicated if the player can interact with an item. The indicator should be a floating "E"
 */

public class itemInteractUI : MonoBehaviour
{
    private TMP_Text myText;// Variable to hold the text
    private Vector2 distance;// Holds distance between player and item

    private ItemScript[] items; // Keep track of all items
    private ItemScript item; // Keep track of one item

    private PlayerScript player;// Grab Player

    // Position of player
    private float playerPosX;
    private float playerPosY;

    void Awake()
    {
        // Initialize text
        myText = GetComponent<TMP_Text>();
        myText.enabled = false;

        player = FindAnyObjectByType<PlayerScript>();// Grab player

        // Grab all objects with ItemScript and put them in an array
        items = FindObjectsByType<ItemScript>(FindObjectsSortMode.None);

    }

    // Update is called once per frame
    void Update()
    {
        // Update items list
        items = FindObjectsByType<ItemScript>(FindObjectsSortMode.None);


        // Iterate through all items
        foreach (ItemScript stuff in items)
        {
            // Calculate distance for each enemy
            distance = stuff.transform.position - player.transform.position;

            // Grab the enemy closest to player. Assume there aren't two enemies close to player
            if (distance.magnitude <= 1)
            {
                item = stuff;
            }

        }

        // Check to see if we grabbed a valid enemy, as well as check to see we're not in combat
        if (item != null)
        {
            // Turn on text
            myText.enabled = true;

            // Track player position and have text follow player
            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            transform.position = new Vector2(playerPosX + 1, playerPosY + 1);

        }

        else { myText.enabled = false; }// Leave text off if conditions aren't met


        //Reset item
        item = null;

    }
}
