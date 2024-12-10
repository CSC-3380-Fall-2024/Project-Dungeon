using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*

Author: Ryan Tin Tran
Description: The purpose of this script is to handle the ItemSlot UI.
This Script grabs the item's name, quantity, and sprite image to display

Date Created: 12/1/2024
Date Updated: 12/6/2024

Update log:

12/6/2024: Add an emptySlot sprite

*/

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    //===========ITEM DATA===========//
    public string itemName;// Grab item name
    public int quantity; // Grab item quantity
    public Sprite itemSprite; // Grab item's sprite
    public bool isFull;// Keep track of whether the item slot is taken or not
    public string itemDescription; // This is what will be the item's description

    [SerializeField]
    public Sprite emptySlot; // This is what the sprite will be when the slot is empty


    //===========ITEM SLOT===========//
    [SerializeField]
    public TMP_Text quantityText;// Grab the text component 

    [SerializeField]
    public Image itemImage;// Grab the item image

    //===========ITEM SELECTED===========//
    public GameObject selectedShader; // Grab the selected shader
    public bool itemSelected;// Keep track if the item is selected

    //===========ITEM DESCRIPTION SLOT===========//
    [SerializeField]
    public Image itemDescriptionImage; // Grab the image for item description

    [SerializeField]
    public TMP_Text itemDescriptionNameText;// Grab the text box for item name in description

    [SerializeField]
    public TMP_Text itemDescriptionText;// Grab text box for item's description

    //===========Others===========//

    public InventoryManager manager;// Grab the inventory manager

    public PlayerScript player; // Grab the player

    private MovementScript movement;// Variable for the movement of the player

    private EnemyScript[] enemy;// Variable for all enemies

    private void Start()
    {
        // Initialize the inventory manager
        manager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

        // Initialize the player
        player = FindAnyObjectByType<PlayerScript>();

        // Initialize the enemy
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        //Find the movement script for the player
        movement = FindAnyObjectByType<MovementScript>();

    }

    void Update()
    {

        // Update list of enemies
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

    }


/*
    *Function: AddItem
    * Author: Ryan Tin Tran
    * Description: This function take the item's name, quantity, and sprite given
    * and set it to the item Slot
    *
    * Date created: 12/1/2024
    * Date modified: 12/1/2024
    */
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;// Set the item's name to the one given
        this.quantity = quantity;// Set the item's quantity to the one given
        this.itemSprite = itemSprite;// Set the item's sprite to the one given
        this.itemDescription = itemDescription; // Set the item's description

        // Indicate that the slot is taken now
        isFull = true;

        // Display the quantity
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;

        // Display the item's image
        itemImage.sprite = itemSprite;

    }

    /*
    *Function: OnPointerClick
    * Author: Ryan Tin Tran
    * Description: This function determines two things:
    * 
    * 1) If the user left click on the item, they check the description
    * 2) If the user right clicks on the item, they use the item
    *
    * Date created: 12/1/2024
    * Date modified: 12/7/2024
    */
    public void OnPointerClick(PointerEventData eventData)
    {
        //Check if the player is in combat or not

        if(player.FightCheck == false)
        {

            // If the user left clicks:
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                // Call the left click function
                OnLeftClick();

            }

            // Else if the user right clicks:
            else if(eventData.button == PointerEventData.InputButton.Right)
            {
                // Call right click function
                OnRightClick();

            }

            else if (eventData.button == PointerEventData.InputButton.Middle)
            {

                // Call drop function
                drop();
                
            }

        }

        else
        {

            // If the user left clicks:
            if(eventData.button == PointerEventData.InputButton.Left)
            {
                // Call the left click function
                OnLeftClick();

            }

            // Else if the user right clicks:
            else if(eventData.button == PointerEventData.InputButton.Right)
            {
                // Call right click function
                useInCombat();

            }

        }



    }

    /*
    *Function: OnLeftClick
    * Author: Ryan Tin Tran
    * Description: This function allows the user to select and view the item description
    * If the user left clicks on an item
    * 
    * Date created: 12/1/2024
    * Date modified: 12/3/2024
    */
    public void OnLeftClick()
    {
        // In case that a previous slot is selected, turn off all shaders that indicate a slot is selected
        manager.deselectAllSlots();

        // Set the shader for this specific slot
        selectedShader.SetActive(true);

        // Indicate that this slot is selected
        itemSelected = true;

        // Set the item's name in the description
        itemDescriptionNameText.text = itemName;

        // Set the text in the item description
        itemDescriptionText.text = itemDescription;

        // Set the image in the item description
        itemDescriptionImage.sprite = itemSprite;

    }


/*
    *Function: OnRightClick
    * Author: Ryan Tin Tran
    * Description: This function allows the user to use a item by calling
    * the UseItem function from the inventory manager to know if the item is
    * usable, as well as passing the item's name
    * 
    * Date created: 12/1/2024
    * Date modified: 12/4/2024
    */
    public void OnRightClick()
    {
        // Call the use item function from the inventory manager
        // and find if the item is usable
        bool usable = manager.UseItem(itemName);

        if(usable)
        {
            // Reduce the item's quantity by 1
            this.quantity -= 1;

            // Update the quantity
            quantityText.text = this.quantity.ToString();

            // If there is no more items, empty the slot
            if(this.quantity <= 0) {EmptySlot();}
        }
    }


    /*
    *Function: useInCombat
    * Author: Ryan Tin Tran
    * Description: 
    * 
    * Date created: 12/7/2024
    * Date modified: 12/7/2024
    */
    public void useInCombat()
    {
        foreach (EnemyScript badGuy in enemy)// Iterate through all enemies
        {
            if (badGuy.FightCheck == true && player.FightCheck == true)// Make sure the enemy is in combat
            {
                if (player.speed >= badGuy.speed) // if player's speed is greater or equal to enemy's, player moves first
                {
                    DefCheck defCheck = new DefCheck();
                    double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction

                    OnRightClick(); // Player uses the Item

                    player.Health = DmgCalc.EnemyAttack(badGuy.Attack, playerdefReduction, player.Health); // enemy attacks second

                    //Check if player health is 0
                    if (player.Health <= 0)
                    {
                        // Exit combat
                        player.FightCheck = false;
                        badGuy.FightCheck = false;
                        movement.enabled = true;

                    }

                    ////////////Disable menu////////////

                    //Set the timescale to 1, or unpauses the game
                    Time.timeScale = 1;

                    // Turn off inventory manager
                    manager.Inventory.SetActive(false);
                    
                    // The menu isn't activated anymore
                    manager.menuActivated = false;

                }
                else // If enemy speed is greater than player's, enenmy attacks first
                {
                    DefCheck defCheck = new DefCheck();
                    double playerdefReduction = defCheck.DamageReduction(player.defense); // takes player's defense and returns the damage reduction

                    player.Health = DmgCalc.EnemyAttack(badGuy.Attack, playerdefReduction, player.Health); // enemy attacks first

                    //Check if player health is 0
                    if (player.Health <= 0)
                    {
                        // Exit combat
                        player.FightCheck = false;
                        badGuy.FightCheck = false;
                        movement.enabled = true;

                    }

                    OnRightClick(); // Player uses the Item

                    ////////////Disable menu////////////

                    //Set the timescale to 1, or unpauses the game
                    Time.timeScale = 1;

                    // Turn off inventory manager
                    manager.Inventory.SetActive(false);
                    
                    // The menu isn't activated anymore
                    manager.menuActivated = false;
                }

            }
            

        }
    }


/*
    *Function: EmptySlot
    * Author: Ryan Tin Tran
    * Description: This function empties an item slot if there are no more items
    * Date created: 12/4/2024
    * Date modified: 12/4/2024
    */

    private void EmptySlot()
    {
        // Empty out item name
        itemName = "";

        // Empty out item sprite
        itemSprite = null;

        // Empty out itemDescription
        itemDescription = "";

        // Turn off the quantity text
        quantityText.enabled = false;

        // Remove item image in the item slot
        itemImage.sprite = emptySlot;

        // Empty the item name
        itemDescriptionNameText.text = "";

        // Empty the item description
        itemDescriptionText.text = "";

        // Empty the item image in the description
        itemDescriptionImage.sprite = null;

        // Indicate that the slot is now not full
        isFull = false;



    }

    public void drop()
    {
        // Create a game object
        GameObject itemToDrop = new GameObject(itemName);

        // Add item script to game object
        Item newItem = itemToDrop.AddComponent<Item>();

        // Set the quantity
        newItem.quantity = 1;

        // Set the item's name
        newItem.itemName = itemName;

        // Set the item's sprite
        newItem.sprite = itemSprite;

        // Set item description
        newItem.itemDescription = itemDescription;

        // Create and modify Sprite renderer
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();

        // Set the sprite renderer
        sr.sprite = itemSprite;

        // Set the sorting layer
        sr.sortingLayerName = "Player";

        //Set the location
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position;

        //Subtract the item

        this.quantity -= 1;

        quantityText.text = this.quantity.ToString();

        if(this.quantity <=0)
        {
            EmptySlot();
        }
        
        
    }
}
