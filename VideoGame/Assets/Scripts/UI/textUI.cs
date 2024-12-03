using UnityEngine;
using TMPro;// Note: This is how you keep the Text UI in a variable

/*
 * Author: Ryan Tin Tran
<<<<<<< HEAD
 * Last Updated: 11/18/2024
 * Description: Enables or disables text for the combat UI depending whether player is in combat or not
=======
 * Last Updated: 11/7/2024
 * Description: Enables or disables text depending on CombatScript fightCheck
>>>>>>> main
 */

public class textUI : MonoBehaviour
{
    // Private Variables
    private TMP_Text myText; // Holds a variable for the TextMeshPro component
<<<<<<< HEAD
    private PlayerScript player;// Holds variable for player
=======
>>>>>>> main

    // Initialize and disable the text
    void Awake()
    {
<<<<<<< HEAD
        player = FindAnyObjectByType<PlayerScript>();// Find player

        // Initialize text
        myText = GetComponent<TMP_Text>();
        myText.enabled = player.FightCheck;
=======
        myText = GetComponent<TMP_Text>();
        myText.enabled = CombatScript.fightCheck;
>>>>>>> main

    }

    // Track the fightCheck
    void Update()
    {
<<<<<<< HEAD
        // Turn on when player is in combat
        myText.enabled = player.FightCheck;
=======

        myText.enabled = CombatScript.fightCheck;
>>>>>>> main

    }
}
