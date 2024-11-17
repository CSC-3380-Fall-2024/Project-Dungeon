using UnityEngine;

public class Combat : MonoBehaviour
{
    private MovementScript movement;

    private EnemyScript enemy;
    private Vector2 enemyFightPos;

    private PlayerScript player;
    private Vector2 playerFightPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemy = FindAnyObjectByType<EnemyScript>();
        enemyFightPos = new Vector2(2,0);

        movement = FindAnyObjectByType<MovementScript>();

        player = FindAnyObjectByType<PlayerScript>();
        playerFightPos = new Vector2(-2, 0);
    }

    // Update is called once per frame
    void Update()
    {


        if (enemy.FightCheck == true && player.FightCheck == true)
        {
            movement.enabled = false;

            enemy.transform.position = enemyFightPos;

            player.transform.position = playerFightPos;
        
        }


    }
}
