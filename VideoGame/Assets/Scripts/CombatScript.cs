using UnityEngine;
using System;

public class CombatScript : MonoBehaviour
{
    public static double distance;
    public static bool fightCheck;
    public static MovementScript movement;

    void Start()
    {

        fightCheck = false;
        movement = GetComponent<MovementScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (fightCheck == false && Input.GetKey(KeyCode.E) && distance < 1)
        {
            fightCheck = true;

            movement.enabled = false;
            Debug.Log("Engage Combat");
            Debug.Log("Player health: " + PlayerInteract.playerHealth);
            Debug.Log("Enemy health: " + EnemyInteract.enemyHealth);
        }


        
        else if (fightCheck == true && Input.GetKey(KeyCode.R))
        {

            //Disengage
            fightCheck = false;

            movement.enabled = true;
            Debug.Log("Disengage Combat");



        }

        if (fightCheck == true && Input.GetKeyUp(KeyCode.F))
        {

            EnemyInteract.enemyHealth -= PlayerInteract.playerAttack;

            Debug.Log("Player dealt: " + PlayerInteract.playerAttack);

            PlayerInteract.playerHealth -= EnemyInteract.enemyAttack;

            Debug.Log("Enemy dealt: " + EnemyInteract.enemyAttack);

            Debug.Log("Player health: " + PlayerInteract.playerHealth);
            Debug.Log("Enemy health: " + EnemyInteract.enemyHealth);
        }

            if (PlayerInteract.playerHealth <= 0)
            {

                Debug.Log("Player is defeated");
                fightCheck = false;
                movement.enabled = true;

            }

            else if (EnemyInteract.enemyHealth <= 0)
            {

                Debug.Log("Enemy is defeated");
                fightCheck = false;
                movement.enabled = true;

            }

        
    }
}
