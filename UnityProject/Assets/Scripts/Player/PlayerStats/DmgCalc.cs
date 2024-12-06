using TMPro.Examples;
using UnityEngine;

/*
 * Author: Kaden Casey
 * Last Updated: 11/27/2024
 * Last Updated by: Ryan Tran
 * Update log: 
 * - Removed comments for damage (11/27/2024)
 * Description: The purpose of this script is calculate damage between player and enemy whenever used by Attack Button
 */

public class DmgCalc
{
    public static double PlayerAttack(double playerAttack, double enemyDefReduction, double enemyHealth) // input player's atk stat, enemy's defense reduction and health
    {
        double playerDamage = playerAttack * enemyDefReduction; // finds damage

        if (playerDamage <= 0) // checks for negative numbers and 0
        {
            //////////////// No need to display in console////////////////
            //Debug.Log("Player dealt no damage"); // if damage would be 0 or negative for any reason, deal no damage
            return enemyHealth;
        }
        else
        {
            enemyHealth -= playerDamage; // subtracts the damage from enemy health

            //////////////// No need to display in console////////////////
            //Debug.Log("Player dealt: " + playerDamage);

            return enemyHealth;
        }

    }

    public static double EnemyAttack(double enemyAttack, double playerDefReduction, double playerHealth) // input enemy's atk stat, player's defense reduction and health
    {
        double enemyDamage = enemyAttack * playerDefReduction; // finds damage

        if (enemyDamage <= 0) // checks for negative numbers and 0
        {
            //////////////// No need to display in console////////////////
            //Debug.Log("Enemy dealt no damage");
            return playerHealth;
        }
        else
        {
            playerHealth -= enemyDamage; // subtracts the damage from player health

            //////////////// No need to display in console////////////////
            //Debug.Log("Enemy dealt: " + enemyDamage);

            return playerHealth;
        }
    }
}
