using UnityEngine;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: A script to make sure the camera follows the player
 */

public class FollowPlayer : MonoBehaviour
{
    private Vector3 fightPos;// Set the position of the camera if in combat

    private PlayerScript player;// Grab the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize fighting position for camera
        fightPos = new Vector3(6f, -26f, -10f);

        // Find the player
        player = FindAnyObjectByType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        // If player isn't in combat, follow the player
        if (player.FightCheck == false)
        {
            transform.localPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        }

        // Else assume fight position
        else if (player.FightCheck == true)
        {
            transform.localPosition = fightPos;
        }
    }
}
