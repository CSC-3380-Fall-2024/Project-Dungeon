using UnityEngine;

/*

Author: Ryan Tin Tran
Description: The purpose of this script is to allow the items to 
be consumed. For now, the items can heal the player

Date Created: 12/3/2024
Date Updated: 12/3/2024

*/

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{   
    // Keep track of the item's name
    public string itemName;

    // Create a variable that determines which stat to change
    public StatToChange statToChange = new StatToChange();

    // Determine how much this item will change
    public int amountToChange;

    // Grab the player so we can change the stats
    public PlayerScript player;


    /*

    Function: UseItem
    Author: Ryan Tin Tran
    Description: This function allows the item to change the player's stats
    depending on what the item wants to change, as well as indicating if the item can be used or not.
    For now, the item can only heal the player

    Date Created: 12/3/2024
    Date Updated: 12/4/2024

    */
    public bool UseItem()
    {
        // If the item wants to change health:
        if(statToChange == StatToChange.health)
        {
            //Find the player script
            player = FindAnyObjectByType<PlayerScript>();

            // Check if the player's health is maxxed out or not.

            // If player is at max health:
            if(player.Health == player.MaxHealth)
            {
                // Indicate the item isn't usable
                return false;

            }

            // If the player's health is a little bit under max health:
            else if(player.Health < 20 && player.Health > player.MaxHealth - amountToChange)
            {
                // Heal player to max
                player.Health = player.MaxHealth;

                // Indicate the item is usable
                return true;

            }

            // If player's health is a lot under max health:
            else
            {

                // Increase player's health by amount
                player.Health += amountToChange;

                // Indicate that the item is usable
                return true;

            } 
        }
        // This is here in case all other cases fail
        return false;

    }


/*

    Enum: UseItem
    Author: Ryan Tin Tran
    Description: This enum keeps track of what the items can change.
    For now, it's just health

    Date Created: 12/3/2024
    Date Updated: 12/3/2024

    */
    public enum StatToChange
    {

        none,
        health

    };
}
