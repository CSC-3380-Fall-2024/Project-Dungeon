using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    public static double distance;
    private bool fightCheck;
    private MovementScript movement;

    void Start()
    { 
    
        fightCheck = false;
        movement = GetComponent<MovementScript>();

    }

    void FixedUpdate()
    {
        if (fightCheck == false) 
        {

            double playerPosX = transform.position.x;
            double playerPosY = transform.position.y;


            double deltaX = playerPosX - EnemyInteract.enemyPosX;
            double deltaY = playerPosY - EnemyInteract.enemyPosY;

            distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

        }

        if (fightCheck == false && Input.GetKey(KeyCode.E) && distance < 1)
        {

                transform.position = new Vector2(-2, 0);
                fightCheck = true;
                movement.enabled = false;
                Debug.Log("Engage Combat");

            

        }

        else if(fightCheck == true && Input.GetKey(KeyCode.R))
        {

                //Disengage
                fightCheck = false;
                movement.enabled = true;
                Debug.Log("Disengage Combat");

            

        }
    }


}
