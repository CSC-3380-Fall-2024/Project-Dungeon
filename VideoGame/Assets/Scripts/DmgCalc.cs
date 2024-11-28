using TMPro.Examples;
using UnityEngine;

public class DmgCalc : MonoBehaviour
{
    public static double PlayerAttack(double playerAttack, double enemyDefReduction, double enemyHealth) // input player's atk stat, enemy's defense reduction and health
    {
        double playerDamage = playerAttack * enemyDefReduction; // finds damage

        if (playerDamage <= 0) // checks for negative numbers and 0
        {
            Debug.Log("Player dealt no damage"); // if damage would be 0 or negative for any reason, deal no damage
            return enemyHealth;
        }
        else
        {
            enemyHealth -= playerDamage; // subtracts the damage from enemy health
            Debug.Log("Player dealt: " + playerDamage);
            return enemyHealth;
        }

    }

    public static double EnemyAttack(double enemyAttack, double playerDefReduction, double playerHealth) // input enemy's atk stat, player's defense reduction and health
    {
        double enemyDamage = enemyAttack * playerDefReduction; // finds damage

        if (enemyDamage <= 0) // checks for negative numbers and 0
        {
            Debug.Log("Enemy dealt no damage");
            return playerHealth;
        }
        else
        {
            playerHealth -= enemyDamage; // subtracts the damage from player health
            Debug.Log("Enemy dealt: " + enemyDamage);
            return playerHealth;
        }
    }
}
