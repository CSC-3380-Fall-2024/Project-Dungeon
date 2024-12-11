using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Author: Ryan Tin Tran
 * Date created: 12/9/2024
 * Last Updated: 12/9/2024
 * 
 * Description: This is the script that will reset the game
 */

public class RestartButton : MonoBehaviour
{
    /*
     * Function: Restart
     * Author: Ryan Tran
     * Description: This is the function that will be called when the player wants
     * to start over
     */
    public void Restart()
    {
        // Unpause game
        Time.timeScale = 1;

        // Load the scene again
        SceneManager.LoadScene("1) The Game");

    }
}
