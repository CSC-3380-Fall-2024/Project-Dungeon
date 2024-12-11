using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void playScene()
    {
        SceneManager.LoadScene("1) The Game");
    }

    public void controlScene()
    {
        SceneManager.LoadScene("2) The controls");
    }

    public void inventoryControl()
    {
        SceneManager.LoadScene("4) Inventory Controls");
    }

    public void BasicControl()
    {
        SceneManager.LoadScene("3) Basic Controls");
    }

    public void StatMenuControl()
    {
        SceneManager.LoadScene("5) Stat Menu Controls");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("0) Title Screen");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
