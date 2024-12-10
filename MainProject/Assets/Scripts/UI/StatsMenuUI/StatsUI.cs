using UnityEngine;
using TMPro;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] StatBlocks;
    public GameObject StatsPanel;
    [SerializeField] private PlayerScript player;

    public bool MenuOpened = false; // boolean to check if menu for stats is opened or closed
    void Start()
    {
        StatsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            UpdateStats();
            ToggleStatsMenu();
        }
    }
    private void ToggleStatsMenu()
    {
        if (!MenuOpened)
        {
            StatsPanel.SetActive(true); // Opens menu
            MenuOpened = true;
        }
        else
        {
            StatsPanel.SetActive(false); // Closes menu
            MenuOpened = false;
        }
    }

    public void UpdateStats()
    {
        StatBlocks[0].GetComponentInChildren<TMP_Text>().text = "Attack: " + player.Attack;
        StatBlocks[1].GetComponentInChildren<TMP_Text>().text = "Defense: " + player.defense;
        StatBlocks[2].GetComponentInChildren<TMP_Text>().text = "Speed: " + player.speed;
        StatBlocks[3].GetComponentInChildren<TMP_Text>().text = "HP/MaxHP: " + player.Health + "/" + player.MaxHealth;
    }


}
