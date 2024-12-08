using UnityEngine;
using System.Collections.Generic;

/*
Author: Ryan Tin Tran
Date Created: 12/1/2024
Date Updated: 12/3/2024
Description: This is the script placed in the Canvas
That will handle the inventory. The purpose of this
script is:

1) Toggle the inventory using the button "I"
2) If an item has been picked up, as told by the Item script,
it will pass the item to the ItemSlot script
3) Provide the function that deselects the "selected" shader that surrounds the item slots
4) Pass information from the Item script to ItemSO script to determine which item is being used

*/

public class InventoryManager : MonoBehaviour
{
    //Grab the object we want to togggle on and off. In this case, it's Inventory Manager
    public GameObject Inventory;

    // Keep track when the menu is activated
    public bool menuActivated;

    // Keep track of all the item slots
    public ItemSlot[] itemSlot;

    // Keep track of all scritable objects
    public ItemSO[] itemSO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inventory is turned off in the beginning
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    // The button attributed to Inventory is "I"
    void Update()
    {
        // Turn off menu if it's already up
        if(Input.GetKeyUp(KeyCode.I) && menuActivated)
        {
            //Set the timescale to 1, or unpauses the game
            Time.timeScale = 1;

            // Turn off inventory manager
            Inventory.SetActive(false);
            
            // The menu isn't activated anymore
            menuActivated = false;

        }
        // Turn on menu if it's not already up
        else if(Input.GetKeyUp(KeyCode.I) && !menuActivated)
        {
            //Set the timescale to 0, or pauses the game
            Time.timeScale = 0;

            // Turn on inventory manager
            Inventory.SetActive(true);

            // The menu is now activated
            menuActivated = true;

        }
    }


/*
    *Function: UseItem
    * Author: Ryan Tin Tran
    * Description: This function cycles through all scriptable objects there is in the game
    * Once it finds the scriptable object that matches the item name provided, we call the
    * UseItem function that is attributed to the scriptable object. Then we see if the item can 
    * be used
    * 
    * Date created: 12/3/2024
    * Date modified: 12/4/2024
    */
    public bool UseItem(string itemName)
    {
        // Cycle through the list of scriptable objects
        for (int i = 0; i < itemSO.Length; i++)
        {
            // When we find the right one:
            if(itemSO[i].itemName == itemName)
            {
                // Call the UseItem function on that scritable object
                // and see if the item can be used
                bool usable = itemSO[i].UseItem();

                // Return the response from the UseItem from the scriptable object
                return usable;

            }

        }
        return false;
    }

    /*
    *Function: AddItem
    * Author: Ryan Tin Tran
    * Description: This function takes an item's name, quantity, and sprite.
    * Once that is done, pass the parameters to the AddItem function in the
    * ItemSlot script
    *
    * Date created: 11/30/2024
    * Date modified: 12/1/2024
    */
    public bool AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {   
        // Assume item addition failed at first
        bool result = false;

        // Iterate through all item slotes
        for(int i = 0; i < itemSlot.Length; i++)
        {
            // Check if that itemSlot is taken. If not, fill it with something
            if(itemSlot[i].isFull == false)
            {
                //Add that item into the item slot
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                // Addition is successful
                result = true;

                // Stop looking for an available slot
                break;

            }

        }

        // After checking all item slots, return the result
        return result;

    }

/*
    *Function: deselectAllSlots
    * Author: Ryan Tin Tran
    * Description: This function is here to deselect the "selected" shader from all item slots. 
    * This function is mainly used by the script itemSlot
    * Date created: 12/2/2024
    * Date modified: 12/3/2024
    */
    public void deselectAllSlots()
    {
        // Cycle through all item slots
        for(int i = 0; i < itemSlot.Length; i++)
        {
            // Turn off the "selected" shader
            itemSlot[i].selectedShader.SetActive(false);

        }

    }
}