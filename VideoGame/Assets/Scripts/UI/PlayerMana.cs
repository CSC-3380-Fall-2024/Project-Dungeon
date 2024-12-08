using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran(edited by Ashton Williams)
 * Last Updated: 11/23/2024
 * Description: This is the UI for the player's mana.
 */
public class PlayerMana : MonoBehaviour
{
    private TMP_Text manaUI;// Grab text for mana
    private bool fightCheck;// Grab fight check from player

    private PlayerScript player;// Grab the layer

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

        // If in combat, turn on health UI
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
