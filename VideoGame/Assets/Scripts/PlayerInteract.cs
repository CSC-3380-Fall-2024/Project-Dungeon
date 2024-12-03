using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    public static double playerPosX;
    public static double playerPosY;
    public static bool fightCheck;

    public static double playerHealth;
    public static double playerAttack;

    void Start()
    { 
    
        fightCheck = CombatScript.fightCheck;

        playerHealth = 20;
        playerAttack = 5;

    }

    void FixedUpdate()
    {
        fightCheck = CombatScript.fightCheck;

        if (fightCheck == false)
        {
            playerPosX = transform.position.x;
            playerPosY = transform.position.y;
        }
        else if (fightCheck == true)
        {
            transform.position = new Vector2(-2, 0);
        }
    }
    


}