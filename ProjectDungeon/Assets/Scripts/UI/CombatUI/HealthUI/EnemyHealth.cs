using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: This is the UI for the enemy's health
 */

public class EnemyHealth : MonoBehaviour
{
    private TMP_Text healthUI;// Grab text for health

    private EnemyScript[] enemies;// Grab list of enemies
    private EnemyScript enemy;// Grab a valid enemy

    // Track position of enemy
    private float enemyPosX;
    private float enemyPosY;

    void Awake()
    {
        // Find all enemies
        enemies = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None);

        // Initialize health UI
        healthUI = GetComponent<TMP_Text>();
        healthUI.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        // Iterate through all enemies
        foreach (EnemyScript badGuy in enemies)
        {
            // If the enemy is in combat, grab the enemy
            // Assume the player only fights one enemy
            if (badGuy.FightCheck == true)
            {
                enemy = badGuy;
            }

        }

        // If valid enemy found and enemy is in combat, do this:
        if (enemy != null && enemy.FightCheck == true)
        {
            // Turn on health UI and display above enemy
            enemyPosX = enemy.transform.position.x;
            enemyPosY = enemy.transform.position.y;

            healthUI.enabled = true;

            healthUI.text = "Health: " + enemy.Health;

            transform.position = new Vector2(enemyPosX, enemyPosY + 2f);

        }

        else
        {

            healthUI.enabled = false;

        }

        // Reset enemy
        enemy = null;

    }
}
