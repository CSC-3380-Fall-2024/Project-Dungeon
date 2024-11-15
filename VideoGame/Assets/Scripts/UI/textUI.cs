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

    // Initialize and disable the text
    void Awake()
    {
        myText = GetComponent<TMP_Text>();
        myText.enabled = CombatScript.fightCheck;

    }

    // Track the fightCheck
    void Update()
    {

        myText.enabled = CombatScript.fightCheck;

    }
}
