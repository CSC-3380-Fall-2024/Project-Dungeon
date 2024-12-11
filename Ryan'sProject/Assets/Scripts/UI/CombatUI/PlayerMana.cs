using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 12/7/2024
 * Updated by: Ashton Williams
 * Description: This is the UI for the player's Mana, being repurposed 
 * for such from the player health script.
 */
public class PlayerMana : MonoBehaviour
{
    private TMP_Text manaUI;// Grab text for mana
    private bool fightCheck;// Grab fight check from player

    private PlayerScript player;// Grab the player

    // Track position of player
    private float playerPosX;
    private float playerPosY;

    void Awake()
    { 
        // Find player
        player = FindAnyObjectByType<PlayerScript>();

        // Initialize mana UI
        manaUI = GetComponent<TMP_Text>();
        fightCheck = player.FightCheck;
        manaUI.enabled = fightCheck;


    }

    // Update is called once per frame
    void Update()
    {
        // Update fight check
        fightCheck = player.FightCheck;

        // If in combat, turn on mana UI
        if (fightCheck == true)
        {
            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            manaUI.enabled = fightCheck;

            manaUI.text = "Mana: " + player.Mana;

            transform.position = new Vector2(playerPosX, playerPosY + 2f);

        }

        else if (fightCheck == false)
        {

            manaUI.enabled = fightCheck;

        }


    }
}
