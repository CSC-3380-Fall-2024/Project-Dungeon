using UnityEngine;
using TMPro;// Note: This is how you keep the Text UI in a variable

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: Enables or disables text depending on CombatScript fightCheck
 */

public class textUI : MonoBehaviour
{
    // Private Variables
    private TMP_Text myText; // Holds a variable for the TextMeshPro component
    private PlayerScript player;

    // Initialize and disable the text
    void Awake()
    {
        player = FindAnyObjectByType<PlayerScript>();

        myText = GetComponent<TMP_Text>();
        myText.enabled = player.FightCheck;

    }

    // Track the fightCheck
    void Update()
    {

        myText.enabled = player.FightCheck;

    }
}
