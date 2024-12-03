using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
<<<<<<< HEAD
 * Last Updated: 11/18/2024
=======
 * Last Updated: 11/9/2024
>>>>>>> main
 * Description: This is the UI to indicated if the player can interact with something. The indicator should be a floating "E"
 */

public class interactUI : MonoBehaviour
{
<<<<<<< HEAD

    private TMP_Text myText;// Variable to hold the text
    private Vector2 distance;// Holds distance between player and enemies

    private PlayerScript player;// Grab Player
    private EnemyScript[] enemies;// Grab enemies
    private EnemyScript enemy;// Grab only one enemy

    // Position of player
    private float playerPosX;
    private float playerPosY;

    void Awake()
    {
        // Initialize text
        myText = GetComponent<TMP_Text>();
        myText.enabled = false;

        player = FindAnyObjectByType<PlayerScript>();// Grab player

        enemies = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);// Graby enemies

=======
    private float posX;
    private float posY;

    private TMP_Text myText;

    void Awake()
    {

        myText = GetComponent<TMP_Text>();
        myText.enabled = false;

>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        // Iterate through all enemies
        foreach (EnemyScript badGuy in enemies)
        {
            // Calculate distance for each enemy
            distance = badGuy.transform.position - player.transform.position;

            // Grab the enemy closest to player. Assume there aren't two enemies close to player
            if (badGuy.FightCheck == false && distance.magnitude <= 1)
            {
                enemy = badGuy;
            }

        }

        // Check to see if we grabbed a valid enemy, as well as check to see we're not in combat
        if (enemy != null && player.FightCheck == false && enemy.FightCheck == false)
        {
            // Turn on text
            myText.enabled = true;

            // Track player position and have text follow player
            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            transform.position = new Vector2(playerPosX + 1, playerPosY + 1);

        }

        else { myText.enabled = false; }// Leave text off if conditions aren't met

        //Reset enemy
        enemy = null;
=======
        if (CombatScript.distance < 1 && CombatScript.fightCheck == false)
        {
            myText.enabled = true;
            posX = (float)PlayerInteract.posX + 1;
            posY = (float)PlayerInteract.posY + 1;

            transform.position = new Vector2(posX, posY);

        }

        else { myText.enabled = false; }
>>>>>>> main

    }
}
