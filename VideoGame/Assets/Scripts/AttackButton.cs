using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public void attack()
    {

        EnemyInteract.enemyHealth -= PlayerInteract.playerAttack;

        Debug.Log("Player dealt: " + PlayerInteract.playerAttack);



        PlayerInteract.playerHealth -= EnemyInteract.enemyAttack;

        Debug.Log("Enemy dealt: " + EnemyInteract.enemyAttack);



        Debug.Log("Player health: " + PlayerInteract.playerHealth);
        Debug.Log("Enemy health: " + EnemyInteract.enemyHealth);

    }

}