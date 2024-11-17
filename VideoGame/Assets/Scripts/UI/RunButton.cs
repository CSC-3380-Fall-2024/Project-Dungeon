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

    private MovementScript movement;

    private PlayerScript player;

    private EnemyScript enemy;

    // Initiate and disable the Button and Image components
    void Awake()
    {

        player = FindAnyObjectByType<PlayerScript>();
        enemy = FindAnyObjectByType<EnemyScript>();

        myButton = GetComponent<Button>();
        myButton.enabled = player.FightCheck;

        myImage = GetComponent<Image>();
        myImage.enabled = player.FightCheck;

        movement = FindAnyObjectByType<MovementScript>();

    }

    // Update to see if the Button and Image component needs to be enabled
    void Update()
    {

        myButton.enabled = player.FightCheck;

        myImage.enabled = player.FightCheck;

    }

    // Function that activates when clicked. Disengaes the fight
    public void run()
    {
        player.FightCheck = false;
        enemy.FightCheck = false;
        movement.enabled = true;
    }

    

    
}
