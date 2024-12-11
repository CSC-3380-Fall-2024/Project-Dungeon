using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject options;// Variable to hold options

    private GameObject controls;// Hold the control menu

    private GameObject basicControls; // Hold the basic control menu
    
    private GameObject inventoryControls; // Hold the inventory controls

    private GameObject statControls; // Hold stat menu controls

    private GameObject skillMenu; // Hold skill tutorial

    private GameObject titlePanel; // Hold the title panel

    private bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Options//
        options = GameObject.Find("OptionsPanel");

        options.SetActive(false);


        // controls//
        controls = GameObject.Find("ControlsPanel");

        controls.SetActive(false);

        // basicControls//
        basicControls = GameObject.Find("BasicControls");

        basicControls.SetActive(false);

        // inventoryControls//
        inventoryControls = GameObject.Find("InventoryControls");

        inventoryControls.SetActive(false);

        // statControls//
        statControls = GameObject.Find("StatMenuControls");

        statControls.SetActive(false);

        // skillMenu//
        skillMenu = GameObject.Find("SkillMenu");

        skillMenu.SetActive(false);

        // titlePanel//
        titlePanel = GameObject.Find("TitlePanel");

        titlePanel.SetActive(false);

        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && !isPaused)
        {
            Time.timeScale = 0;

            options.SetActive(true);

            isPaused = true;

        }
    }
    /// <summary>
    /// This will close the options menu
    /// </summary>
    public void unPause()
    {

        Time.timeScale = 1;

        options.SetActive(false);

        isPaused = false;

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void controlMenu()
    {
        deselectAll();
        controls.SetActive(true);

    }

    /// <summary>
    ///  This will open up the title panel
    /// </summary>
    public void openTitle()
    {

        deselectAll();
        titlePanel.SetActive(true);

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void basicPanel()
    {

        deselectAll();
        basicControls.SetActive(true);

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void statPanel()
    {

        deselectAll();
        statControls.SetActive(true);

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void inventoryPanel()
    {

        deselectAll();
        inventoryControls.SetActive(true);

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void skillPanel()
    {

        deselectAll();
        skillMenu.SetActive(true);

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void returnToOptions()
    {

        deselectAll();
        options.SetActive(true);

    }

    /// <summary>
    ///  This will open up the controls
    /// </summary>
    public void returnToTitle()
    {

        SceneManager.LoadScene("0) Title Screen");

    }
    /// <summary>
    /// Turn off all panels
    /// </summary>
    public void deselectAll()
    {

        // Options//

        options.SetActive(false);

        // controls//

        controls.SetActive(false);

        // basicControls//

        basicControls.SetActive(false);

        // inventoryControls//

        inventoryControls.SetActive(false);

        // statControls//

        statControls.SetActive(false);

        // skillMenu//

        skillMenu.SetActive(false);

        // titlePanel//

        titlePanel.SetActive(false);

    }




}
