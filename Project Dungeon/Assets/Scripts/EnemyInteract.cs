using UnityEngine;

public class EnemyInteract : MonoBehaviour
{

    public static double enemyPosX;
    public static double enemyPosY;
    private bool fightCheck;

    void Start()
    { 
        fightCheck = false;
    }

    void FixedUpdate()
    {
        if (fightCheck == false)
        {
            enemyPosX = transform.position.x;
            enemyPosY = transform.position.y;
        }

        if (fightCheck == false && Input.GetKey(KeyCode.E) && PlayerInteract.distance < 1)
        {
            transform.position = new Vector2(2, 0);
            fightCheck = true;
        }
        else if(fightCheck == true && Input.GetKey(KeyCode.R))
        {
            fightCheck = false;
        }

    }

    
}
