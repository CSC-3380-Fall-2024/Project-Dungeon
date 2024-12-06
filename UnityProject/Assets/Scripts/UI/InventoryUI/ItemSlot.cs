using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*

Author: Ryan Tin Tran
Description: The purpose of this script is to handle the ItemSlot UI.
This Script grabs the item's name, quantity, and sprite image to display

Date Created: 12/1/2024
Date Updated: 12/1/2024

*/

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    //===========ITEM DATA===========//
    public string itemName;// Grab item name
    public int quantity; // Grab item quantity
    public Sprite itemSprite; // Grab item's sprite
    public bool isFull;// Keep track of whether the item slot is taken or not
    public string itemDescription; // This is what will be the item's description


    //===========ITEM SLOT===========//
    [SerializeField]
    private TMP_Text quantityText;// Grab the text component 

    [SerializeField]
    private Image itemImage;// Grab the item image

    //===========ITEM SELECTED===========//
    public GameObject selectedShader; // Grab the selected shader
    public bool itemSelected;// Keep track if the item is selected

    //===========ITEM DESCRIPTION SLOT===========//
    public Image itemDescriptionImage; // Grab the image for item description
    public TMP_Text itemDescriptionNameText;// Grab the text box for item name in description
    public TMP_Text itemDescriptionText;// Grab text box for item's description

    //===========Others===========//

    private InventoryManager manager;// Grab the inventory manager

    
    private void Start()
    {
        // Initialize the inventory manager
        manager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

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
    * Date modified: 12/1/2024
    */
    public void OnPointerClick(PointerEventData eventData)
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
    *Function: EmptySlot
    * Author: Ryan Tin Tran
    * Description: This function empties an item slot if there are no more items
    * Date created: 12/4/2024
    * Date modified: 12/4/2024
    */

    private void EmptySlot()
    {
        // Turn off the quantity text
        quantityText.enabled = false;

        // Remove item image in the item slot
        itemImage.sprite = null;

        // Empty the item name
        itemDescriptionNameText.text = "";

        // Empty the item description
        itemDescriptionText.text = "";

        // Empty the item image in the description
        itemDescriptionImage.sprite = null;



    }
}
