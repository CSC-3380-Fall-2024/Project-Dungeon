using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    private TMP_Text healthUI;
    private bool fightCheck;

    private EnemyScript enemy;

    private float enemyPosX;
    private float enemyPosY;

    void Awake()
    {
        enemy = FindAnyObjectByType<EnemyScript>();

        healthUI = GetComponent<TMP_Text>();
        fightCheck = enemy.FightCheck;
        healthUI.enabled = fightCheck;


    }

    // Update is called once per frame
    void Update()
    {
        fightCheck = enemy.FightCheck;

        if (fightCheck == true)
        {
            enemyPosX = enemy.transform.position.x;
            enemyPosY = enemy.transform.position.y;

            healthUI.enabled = fightCheck;

            healthUI.text = "Health: " + enemy.Health;

            transform.position = new Vector2(enemyPosX, enemyPosY + 2f);

        }

        else if (fightCheck == false)
        {

            healthUI.enabled = fightCheck;

        }


    }
}
