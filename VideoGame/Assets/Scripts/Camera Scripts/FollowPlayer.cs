using UnityEngine;

<<<<<<< HEAD
public class FollowPlayer : MonoBehaviour
{
    private Vector3 fightPos;
=======
/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/18/2024
 * Description: A script to make sure the camera follows the player
 */

public class FollowPlayer : MonoBehaviour
{
    private Vector3 fightPos;// Set the position of the camera if in combat

    private PlayerScript player;// Grab the player
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
<<<<<<< HEAD

        fightPos = new Vector3(0, 0, -10f);

=======
        // Initialize fighting position for camera
        fightPos = new Vector3(0, 0, -10f);

        // Find the player
        player = FindAnyObjectByType<PlayerScript>();
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673

    }

    // Update is called once per frame
    void Update()
    {

<<<<<<< HEAD
        
        if (CombatScript.fightCheck == false)
        {
            transform.position = new Vector3((float)PlayerInteract.posX, (float)PlayerInteract.posY, -10f);
        }
        else if (CombatScript.fightCheck == true)
=======
        // If player isn't in combat, follow the player
        if (player.FightCheck == false)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        }

        // Else assume fight position
        else if (player.FightCheck == true)
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
        {
            transform.position = fightPos;
        }
    }
}
