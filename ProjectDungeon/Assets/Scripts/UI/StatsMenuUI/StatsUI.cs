using UnityEngine;
using TMPro;
public class NewMonoBehaviourScript : MonoBehaviour
{
    //public GameObject[] StatBlocks;
    public TMP_Text[] textBlocks;
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

        textBlocks[0].text = "Attack: " + player.Attack;
        textBlocks[1].text = "Defense: " + player.defense;
        textBlocks[2].text = "Speed: " + player.speed;
        textBlocks[3].text = "HP/MaxHP: " + player.Health + "/" + player.MaxHealth;
        textBlocks[4].text = "Mana/MaxMana: " + player.Mana + "/" + player.MaxMana;
        textBlocks[5].text = "Statpoints: " + player.statPoint;
        textBlocks[6].text = "Level: " + player.level;
    }


}
