using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    private TMP_Text healthUI;
    private bool fightCheck;

    private PlayerScript player;

    private float playerPosX;
    private float playerPosY;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerScript>();

        healthUI = GetComponent<TMP_Text>();
        fightCheck = player.FightCheck;
        healthUI.enabled = fightCheck;


    }

    // Update is called once per frame
    void Update()
    {
        fightCheck = player.FightCheck;

        if (fightCheck == true)
        {
            playerPosX = player.transform.position.x;
            playerPosY = player.transform.position.y;

            healthUI.enabled = fightCheck;

            healthUI.text = "Health: " + player.Health;

            transform.position = new Vector2(playerPosX, playerPosY + 2f);

        }

        else if (fightCheck == false)
        {

            healthUI.enabled = fightCheck;

        }


    }
}
