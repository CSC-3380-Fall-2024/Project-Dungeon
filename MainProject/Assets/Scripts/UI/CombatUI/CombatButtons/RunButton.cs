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

    private MovementScript movement;// Variable for the movement of the player

    private PlayerScript player;// Variable to find player

    private EnemyScript[] enemy;// Variable for all enemies

    private TextBubbleManager textBubble; // Keep track of text bubble

    // Initiate and disable the Button and Image components
    void Awake()
    {
        // Find player and all enemies
        player = FindAnyObjectByType<PlayerScript>();
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        //Find the button for the run button
        myButton = GetComponent<Button>();
        myButton.enabled = player.FightCheck;

        //Find the image for the run button
        myImage = GetComponent<Image>();
        myImage.enabled = player.FightCheck;

        //Find the movement script for the player
        movement = FindAnyObjectByType<MovementScript>();

        // Find text bubble canvas
        textBubble = GameObject.Find("TextBubbleCanvas").GetComponent<TextBubbleManager>();

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

    // Function that activates when clicked. Disengaes the fight
    public void run()
    {
        //Player exits combat
        player.FightCheck = false;

        // Player is returned to original position
        player.transform.localPosition = player.OriginalPosition;

        // Player can move again
        movement.enabled = true;

        // Exit the enemies from combat if they're in combat
        foreach (EnemyScript badGuy in enemy)
        {
            if (badGuy.FightCheck == true)
            {
                badGuy.FightCheck = false;

                badGuy.transform.localPosition = badGuy.OriginalPosition;
            }


        }


        // Call text bubble

        string runString = "You ran away";
        textBubble.turnON(runString);

    }

    

    
}
