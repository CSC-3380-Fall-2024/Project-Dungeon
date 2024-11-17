using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/9/2024
 * Description: This is the UI to indicated if the player can interact with something. The indicator should be a floating "E"
 */

public class interactUI : MonoBehaviour
{

    private TMP_Text myText;
    private Vector2 distance;

    private PlayerScript player;
    private EnemyScript enemy;

    private float playerPosX;
    private float playerPosY;

    void Awake()
    {

        myText = GetComponent<TMP_Text>();
        myText.enabled = false;

        player = FindAnyObjectByType<PlayerScript>();

        enemy = FindAnyObjectByType<EnemyScript>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = enemy.transform.position - player.transform.position;


        if (player.FightCheck == false && enemy.FightCheck == false && distance.magnitude < 1)
        {

            myText.enabled = true;

            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            transform.position = new Vector2(playerPosX + 1, playerPosY + 1);

        }

        else { myText.enabled = false; }

    }
}
