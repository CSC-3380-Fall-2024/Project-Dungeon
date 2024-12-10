using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This is the UI for the player's health
 */
public class PlayerHealth : MonoBehaviour
{
    private TMP_Text healthUI;// Grab text for health
    private bool fightCheck;// Grab fight check from player

    private PlayerScript player;// Grab the layer

    // Track position of player
    private float playerPosX;
    private float playerPosY;

    void Awake()
    { 
        // Find player
        player = FindAnyObjectByType<PlayerScript>();

        // Initialize health UI
        healthUI = GetComponent<TMP_Text>();
        fightCheck = player.FightCheck;
        healthUI.enabled = fightCheck;


    }

    // Update is called once per frame
    void Update()
    {
        // Update fight check
        fightCheck = player.FightCheck;

        // If in combat, turn on health UI
        if (fightCheck == true)
        {
            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            healthUI.enabled = fightCheck;

            healthUI.text = "Health: " + player.Health;

            transform.position = new Vector2(playerPosX, playerPosY + 2f);

        }

        else if (fightCheck == false)
        {

            healthUI.enabled = fightCheck;

        }


    }
}
