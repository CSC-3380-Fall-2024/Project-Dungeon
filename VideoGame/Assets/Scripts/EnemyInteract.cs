using UnityEngine;

public class EnemyInteract : MonoBehaviour
{

    public static double enemyPosX;
    public static double enemyPosY;
    public static bool fightCheck;

    public static double enemyHealth;
    public static double enemyAttack;

    void Start()
    {
        fightCheck = CombatScript.fightCheck;

        enemyHealth = 20;
        enemyAttack = 1;
    }

    void FixedUpdate()
    {
        fightCheck = CombatScript.fightCheck;

        if (fightCheck == false)
        {
            enemyPosX = transform.position.x;
            enemyPosY = transform.position.y;
        }
        else if (fightCheck == true)
        {
            transform.position = new Vector2(2, 0);
        }

    }

    
}