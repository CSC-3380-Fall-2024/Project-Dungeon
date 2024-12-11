using TMPro.Examples;
using UnityEngine;

public class LvlUp : MonoBehaviour
{
    [SerializeField] private PlayerScript player; // allows this class to access PlayerScript
    public EnemyScript badGuy;

    private TextBubbleManager textBubble; // Keep track of text bubble


    void Start()
    {
        if (player == null) // checks for no player reference
        {
            player = FindAnyObjectByType<PlayerScript>(); 

            // No need to print this statemenet
            //Debug.Log("Player reference: " + player); // returns if there is no reference to the player
        }
        badGuy = FindAnyObjectByType<EnemyScript>();

        // Find text bubble canvas
        textBubble = GameObject.Find("TextBubbleCanvas").GetComponent<TextBubbleManager>();

    }

    private int xpForLevel = 20;
    public int xpCheck(int exp, int droppedExp) // input player's current exp and enemy's exp amount they will drop
    {
        exp += droppedExp; // add dropped exp from the enemy to player's exp
        if (exp >= xpForLevel)
        {
            exp -= xpForLevel; // subtracts amount of xp needed for a level up
            if (player != null)
            {
                player.statPoint++; // gives player their xp point to invest into stats
                player.level++; // increment player's level
                //Debug.Log("Leveled up to level " + player.level + "!");
                //Debug.Log("Current XP: " + exp + "/" + xpForLevel);

                // Tell the player
                string levelString = "Leveled up to level " + player.level + "! " + "Current XP: " + exp + "/" + xpForLevel;
                textBubble.turnON(levelString);

                return exp; // returns exp after reducing the amount needed for a level up
            }
            else
            {
                Debug.LogError("Player reference is null bruh"); // This will log an error if player is null
                return exp;
            }
            
        }
        else
        {
            //Debug.Log("Current XP: " + droppedExp + "/" + xpForLevel);

            // Tell the player
            string levelString = "Current XP: " + droppedExp + "/" + xpForLevel;
            textBubble.turnON(levelString);

            return exp; // returns exp after adding how much is dropped by an enemy
        }
    }
}