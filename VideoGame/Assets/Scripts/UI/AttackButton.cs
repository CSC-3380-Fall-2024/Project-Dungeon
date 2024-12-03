using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: The purpose of this script is to mediate damage between the player and enemy.
 * Also checks on the health of the player and enemy and decides the victor
 */

public class AttackButton : MonoBehaviour
{
    //Private Variables
    private Button myButton; // A variable to hold the Button Component
    private Image myImage;  // A variable to hold the Image Component
    public TMP_Text damageNum;

    // Public Variables
    public GameObject enemy; // A variable to hold an enemy GameObject

    // Initiate and disable the Button and Image components
    void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.enabled = CombatScript.fightCheck;

        myImage = GetComponent<Image>();
        myImage.enabled = CombatScript.fightCheck;

    }

    // Update to see if the Button and Image component needs to be enabled
    void Update()
    {

        myButton.enabled = CombatScript.fightCheck;

        myImage.enabled = CombatScript.fightCheck;

    }

    // Function that activates everytime the attack button is clicked. Player and enemy fights
    // Assumes the Player moves first
    public void attack()
    {
<<<<<<< HEAD

        EnemyInteract.health -= PlayerInteract.attack;


        PlayerInteract.health -= EnemyInteract.attack;
=======
        if (PlayerInteract.speed >= EnemyInteract.speed) // if player's speed is greater or equal to enemy's, player attacks first
        {
            //EnemyInteract.health -= PlayerInteract.attack;

            //Debug.Log("Player dealt: " + PlayerInteract.attack);

            //PlayerInteract.health -= EnemyInteract.attack;

            //Debug.Log("Enemy dealt: " + EnemyInteract.attack);

            DefCheck defCheck = new DefCheck();
            double playerdefReduction = defCheck.DamageReduction(PlayerInteract.defense); // takes player's defense and returns the damage reduction
            double enemydefReduction = defCheck.DamageReduction(EnemyInteract.defense); // does the same for the enemy

            EnemyInteract.health = DmgCalc.PlayerAttack(PlayerInteract.attack, enemydefReduction, EnemyInteract.health); // player attacks first
            PlayerInteract.health = DmgCalc.EnemyAttack(EnemyInteract.attack, playerdefReduction, PlayerInteract.health); // enemy attacks second

            Debug.Log("Player health: " + PlayerInteract.health);

            Debug.Log("Enemy health: " + EnemyInteract.health);

        }

        else // If enemy speed is greater than player's, enenmy attacks first
        {
            //PlayerInteract.health -= EnemyInteract.attack;
            //Debug.Log("Enemy dealt: " + EnemyInteract.attack);

            //EnemyInteract.health -= PlayerInteract.attack;
            //Debug.Log("Player dealt: " + PlayerInteract.attack);

            DefCheck defCheck = new DefCheck();
            double playerdefReduction = defCheck.DamageReduction(PlayerInteract.defense); // takes player's defense and returns the damage reduction
            double enemydefReduction = defCheck.DamageReduction(EnemyInteract.defense); // does the same for the enemy

            PlayerInteract.health = DmgCalc.EnemyAttack(EnemyInteract.attack, playerdefReduction, PlayerInteract.health); // enemy attacks first
            EnemyInteract.health = DmgCalc.PlayerAttack(PlayerInteract.attack, enemydefReduction, EnemyInteract.health); // player attacks second

            Debug.Log("Player health: " + PlayerInteract.health);
            Debug.Log("Enemy health: " + EnemyInteract.health);
        }
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

        //Check whose health is 0
        if (PlayerInteract.health <= 0)
        {
<<<<<<< HEAD
=======

            Debug.Log("Player is defeated");
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
            CombatScript.fightCheck = false;
            CombatScript.movement.enabled = true;

        }

        else if (EnemyInteract.health <= 0)
        {
<<<<<<< HEAD
            Destroy(enemy);
            CombatScript.fightCheck = false;
            CombatScript.movement.enabled = true;
=======

            Debug.Log("Enemy is defeated");
            Destroy(enemy);
            CombatScript.fightCheck = false;
            CombatScript.movement.enabled = true;
            LvlUp expCheck = new LvlUp();
            PlayerInteract.exp = expCheck.xpCheck(PlayerInteract.exp, EnemyInteract.dropExp); // after enemy is defeated, gives player xp
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

        }

    }

}