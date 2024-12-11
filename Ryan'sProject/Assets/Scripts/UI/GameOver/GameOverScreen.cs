using UnityEngine;
using UnityEngine.UI;


/*
 * Author: Ryan Tin Tran
 * Date created: 12/9/2024
 * Last Updated: 12/9/2024
 * 
 * Description: This is the script that will turn on the Game Over screen when the player dies
 */

public class GameOverScreen : MonoBehaviour
{
    // Find the game over screen
    private GameObject background;

    public void Awake()
    { 
        // Initialize the variable
        background = GameObject.Find("GameOverBackground");

        // Turn it off
        background.SetActive(false);

    }

    /*
     * Function: Setup
     * Author: Ryan Tran
     * Description: This is the function that will be called by the attack button
     *  when the player dies
     */
    public void Setup()
    {
        // Pause the game
        Time.timeScale = 0;

        // Turn on the game over screen
        background.SetActive(true);

    }
}
