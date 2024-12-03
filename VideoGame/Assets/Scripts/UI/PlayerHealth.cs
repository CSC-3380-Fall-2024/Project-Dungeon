using UnityEngine;
using TMPro;

<<<<<<< HEAD
=======
<<<<<<< HEAD

public class PlayerHealth : MonoBehaviour
{
    private TMP_Text healthUI;
    private bool fightCheck;

    void Awake()
    {
        healthUI = GetComponent<TMP_Text>();
        fightCheck = CombatScript.fightCheck;
        healthUI.enabled = fightCheck;

=======
>>>>>>> main
/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This is the UI for the enemy's health
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


<<<<<<< HEAD
=======
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        fightCheck = CombatScript.fightCheck;

        if (fightCheck == true)
        {

            healthUI.enabled = fightCheck;

            healthUI.text = "Health: " + PlayerInteract.health;

            transform.position = new Vector2(PlayerInteract.fightPosX, PlayerInteract.fightPosY + 2f);
=======
>>>>>>> main
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
<<<<<<< HEAD
=======
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main

        }

        else if (fightCheck == false)
        {

            healthUI.enabled = fightCheck;

        }


    }
}
