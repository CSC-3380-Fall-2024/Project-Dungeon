using UnityEngine;
using TMPro;// Note: This is how you keep the Text UI in a variable

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: Enables or disables text for the combat UI depending whether player is in combat or not
 */

public class textUI : MonoBehaviour
{
    // Private Variables
    private TMP_Text myText; // Holds a variable for the TextMeshPro component
    private PlayerScript player;// Holds variable for player

    // Initialize and disable the text
    void Awake()
    {
        player = FindAnyObjectByType<PlayerScript>();// Find player

        // Initialize text
        myText = GetComponent<TMP_Text>();
        myText.enabled = player.FightCheck;

    }

    // Track the fightCheck
    void Update()
    {
        // Turn on when player is in combat
        myText.enabled = player.FightCheck;

    }
}
