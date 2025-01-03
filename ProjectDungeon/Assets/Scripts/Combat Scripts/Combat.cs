using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This script handles combat. Locks the 
 * enemy and player in a certain spot and turns on Combat UI
 * 
 */

public class Combat : MonoBehaviour
{
    private MovementScript movement;// Grab the movement component of the player

    private EnemyScript[] enemy;// Grab a list of all enemies
    private Vector2 enemyFightPos; // This is the fighting position the enemy will assume

    private PlayerScript player;// This grabs the player script
    private Vector2 playerFightPos;// This is the fighting position for the player

    private TextBubbleManager textBubble; // Keep track of text bubble

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None); // Find all enemies
        enemyFightPos = new Vector2(1f, -73f); // Initialize enemy fighting position

        movement = FindAnyObjectByType<MovementScript>();// Grab the movement script of the player

        player = FindAnyObjectByType<PlayerScript>();// Grab the player
        playerFightPos = new Vector2(-4f , -73f);// Initialize player fighting position

        // Find text bubble canvas
        textBubble = GameObject.Find("TextBubbleCanvas").GetComponent<TextBubbleManager>();
    }

    // Update is called once per frame
    //void Update()
    public void startCombat()
    {
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None); //Update list of enemies

        foreach (EnemyScript badGuy in enemy)// Iterate through all enemies
        {

            if (badGuy.FightCheck == true && player.FightCheck == true)// If both enemy and player are in combat, do this:
            {
                movement.enabled = false; // Disable movement

                // Set the positions of enemy and player
                badGuy.transform.localPosition = enemyFightPos;

                player.transform.localPosition = playerFightPos;

                // Tell the player he is in combat

                string begin = "Begin Combat";
                textBubble.turnON(begin);

                // After all of this the AttackButton and RunButton scripts take care of the rest of combat

            }

        }


    }
}
