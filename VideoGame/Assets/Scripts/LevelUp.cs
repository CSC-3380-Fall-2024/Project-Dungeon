using TMPro.Examples;
using UnityEngine;

public class LvlUp : MonoBehaviour
{
    public PlayerScript player;
    public EnemyScript badGuy;
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        badGuy = FindAnyObjectByType<EnemyScript>();
    }

    private int xpForLevel = 20;
    public int xpCheck(int exp, int droppedExp) // input player's current exp and enemy's exp amount they will drop
    {
        exp += droppedExp; // add dropped exp from the enemy to player's exp
        if (exp >= xpForLevel)
        {
            exp -= xpForLevel; // subtracts amount of xp needed for a level up
            player.statPoint++; // gives player their xp point to invest into stats
            player.level++; // increment player's level
            Debug.Log("Leveled up to level " + player.level + "!");
            Debug.Log("Current XP: " + exp + "/" + xpForLevel);
            return exp; // returns exp after reducing the amount needed for a level up
        }
        else
        {
            Debug.Log("Current XP: " + droppedExp + "/" + xpForLevel);
            return exp; // returns exp after adding how much is dropped by an enemy
        }
    }
}