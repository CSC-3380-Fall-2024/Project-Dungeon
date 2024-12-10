using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*

Author: Ryan Tin Tran
Description: The purpose of this script is to set the functionality of each item.
This script does the following:

1) Keep track of the distance between player and the item to determine if the player 
can interact with the item

2) If the item is collected, pass information to the inventory manager script
and despawn the item

Date Created: 12/1/2024
Date Updated: 12/3/2024

*/

public class Item : MonoBehaviour
{
    [SerializeField]// Makes variable visible and editable in Unity Inspector
    public string itemName;// Grab name of item

    [SerializeField]
    public int quantity; // set quantity

    [SerializeField]
    public Sprite sprite; // Keep track of sprite

    private InventoryManager manager;// Keep Track of inventory manager

    [TextArea]
    [SerializeField]
    public string itemDescription; // This is the item's description

    private PlayerScript player; //Keep track of player

    private Vector2 distance; // Keep track of distance between item and player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find player
        player = FindAnyObjectByType<PlayerScript>();

        // Find Inventory Manager
        manager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update distance between item and player
        distance = player.transform.position - transform.position;

        // If very close and the player press "E":
        if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E))
        {
            // Feed the item name, quantity,sprite, and item description to the InventoryManager
            bool addSuccessful = manager.AddItem(itemName, quantity, sprite, itemDescription);

            if(addSuccessful)
            {

                // Despawn the item
                Destroy(this.gameObject);


            }

        }

    }
}
