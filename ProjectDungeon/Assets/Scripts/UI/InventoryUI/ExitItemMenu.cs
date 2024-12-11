using UnityEngine;
using UnityEngine.EventSystems;

public class ExitItemMenu : MonoBehaviour, IPointerClickHandler
{

    public InventoryManager manager;// Grab the inventory manager

    void Start()
    {

        manager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

    }

    /*
    *Function: OnPointerClick
    * Author: Ryan Tin Tran
    * Description: This function allows the user to
    * Click this button and exit the item menu
    *
    * Date created: 12/7/2024
    * Date modified: 12/7/2024
    */
    public void OnPointerClick(PointerEventData eventData)
    {

        //Set the timescale to 1, or unpauses the game
            Time.timeScale = 1;

            // Turn off inventory manager
            manager.Inventory.SetActive(false);
            
            // The menu isn't activated anymore
            manager.menuActivated = false;

    }
}
