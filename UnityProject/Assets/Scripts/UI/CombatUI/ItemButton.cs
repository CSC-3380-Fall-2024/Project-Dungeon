using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component

    public PlayerScript player;// Variable to find player

    private EnemyScript[] enemy;// Variable for all enemies

    private InventoryManager manager;// Grab the inventory manager
    
    // Initiate and disable the Button and Image components
    void Start()
    {
        // Find player and all enemies
        player = FindAnyObjectByType<PlayerScript>();
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        // Initialize the inventory manager
        manager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

        //Find the button for the attack button
        myButton = GetComponent<Button>();
        myButton.enabled = player.FightCheck;

        //Find the image for the attack button
        myImage = GetComponent<Image>();
        myImage.enabled = player.FightCheck;

    }

    // Update to see if the Button and Image component needs to be enabled
    void Update()
    {
        // Update list of enemies
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        // The buttons and image is enabled depending if the player is in combat or not
        myButton.enabled = player.FightCheck;

        myImage.enabled = player.FightCheck;

    }

    public void useItem()
    {

        // Turn off menu if it's already up
        if(manager.menuActivated)
        {
            //Set the timescale to 1, or unpauses the game
            Time.timeScale = 1;

            // Turn off inventory manager
            manager.Inventory.SetActive(false);
            
            // The menu isn't activated anymore
            manager.menuActivated = false;

        }
        // Turn on menu if it's not already up
        else if(!manager.menuActivated)
        {
            //Set the timescale to 0, or pauses the game
            //Time.timeScale = 0;

            // Turn on inventory manager
            manager.Inventory.SetActive(true);

            // The menu is now activated
            manager.menuActivated = true;

        }

    }
    
}
