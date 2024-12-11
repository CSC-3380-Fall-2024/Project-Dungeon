using TMPro.Examples;
using UnityEngine;
using System;

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
        double playerDamage = Math.Round(playerAttack * enemyDefReduction); // finds damage

        if (playerDamage <= 0) // checks for negative numbers and 0
        {
            return enemyHealth;
        }
        else
        {
            enemyHealth -= playerDamage; // subtracts the damage from enemy health

            return enemyHealth;
        }

    }

    public static double EnemyAttack(double enemyAttack, double playerDefReduction, double playerHealth) // input enemy's atk stat, player's defense reduction and health
    {
        double enemyDamage = Math.Round(enemyAttack * playerDefReduction); // finds damage

        if (enemyDamage <= 0) // checks for negative numbers and 0
        {
            return playerHealth;
        }
        else
        {
            playerHealth -= enemyDamage; // subtracts the damage from player health


            return playerHealth;
        }
    }
}
