using UnityEngine;
using UnityEngine.SceneManagement;

public class allButtons : MonoBehaviour
{
    private PauseMenu pauseManager;

    void Start()
    {

        pauseManager = GameObject.Find("OptionsCanvas").GetComponent<PauseMenu>();

    }

    /// <summary>
    /// unpause the game
    /// </summary>
    public void unpause()
    {

        pauseManager.unPause();


    }

    /// <summary>
    /// Pull up title panael
    /// </summary>
    public void titleButton()
    {

        pauseManager.openTitle();


    }

    /// <summary>
    /// pull up controls menu
    /// </summary>
    public void controlsButton()
    {

        pauseManager.controlMenu();

    }

    /// <summary>
    /// pull up basic controls
    /// </summary>
    public void basicCon()
    {
        pauseManager.basicPanel();


    }

    /// <summary>
    /// pull up stat controls
    /// </summary>
    public void statCon()
    {

        pauseManager.statPanel();

    }

    /// <summary>
    /// pull up inventory controls
    /// </summary>
    public void inventoryCon()
    {

        pauseManager.inventoryPanel();

    }

    /// <summary>
    /// pull up skill controls
    /// </summary>
    public void skilButton()
    {

        pauseManager.skillPanel();

    }

    /// <summary>
    /// return to option
    /// </summary>
    public void returnToOptioin()
    {

        pauseManager.returnToOptions();

    }

    /// <summary>
    /// Go back to title screeen
    /// </summary>
    public void returnToTitle()
    {

        SceneManager.LoadScene("0) Title Screen");

    }
}
