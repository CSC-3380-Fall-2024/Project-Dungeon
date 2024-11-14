using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: The purpose of this script is to mediate damage between the player and enemy.
 * Also checks on the health of the player and enemy and decides the victor
 */

public class AttackButton : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component
    public TMP_Text damageNum;

    // Public Variables
    public GameObject enemy; // A variable to hold an enemy GameObject

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

    // Function that activates everytime the attack button is clicked. Player and enemy fights
    // Assumes the Player moves first
    public void attack()
    {

        EnemyInteract.health -= PlayerInteract.attack;


        PlayerInteract.health -= EnemyInteract.attack;

        //Check whose health is 0
        if (PlayerInteract.health <= 0)
        {
            CombatScript.fightCheck = false;
            CombatScript.movement.enabled = true;

        }

        else if (EnemyInteract.health <= 0)
        {
            Destroy(enemy);
            CombatScript.fightCheck = false;
            CombatScript.movement.enabled = true;

        }

    }

}