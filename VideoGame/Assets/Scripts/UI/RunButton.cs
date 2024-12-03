using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: The purpose of this script is to mediate damage between the player and enemy.
 * Also checks on the health of the player and enemy and decides the victor
 */

public class RunButton : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component

    // Initiate and disable the Button and Image components
    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.enabled = CombatScript.fightCheck;

        myImage = GetComponent<Image>();
        myImage.enabled = CombatScript.fightCheck;

    }

    // Update to see if the Button and Image component needs to be enabled
    void Update()
    {

        myButton.enabled = CombatScript.fightCheck;

        myImage.enabled = CombatScript.fightCheck;

    }

    // Function that activates when clicked. Disengaes the fight
    public void run()
    {
        CombatScript.fightCheck = false;

        CombatScript.movement.enabled = true;

        Debug.Log("Disengage Combat");
    }

    

    
}
