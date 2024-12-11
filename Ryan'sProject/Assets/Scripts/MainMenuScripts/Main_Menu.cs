using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void playScene()
    {
        SceneManager.LoadScene("ModifySkillMenu(Most Recent)");
    }

    public void controlScene()
    {
        SceneManager.LoadScene("ControlsMenu");
    }

    public void inventoryControl()
    {
        SceneManager.LoadScene("InventoryMenuControls");
    }

    public void BasicControl()
    {
        SceneManager.LoadScene("BasicControlsMenu");
    }

    public void StatMenuControl()
    {
        SceneManager.LoadScene("StatMenuControls");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("ModifiedMainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
