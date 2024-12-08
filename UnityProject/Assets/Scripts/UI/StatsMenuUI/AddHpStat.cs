using TMPro.Examples;
using UnityEngine;
using TMPro;

public class AddHpStat : MonoBehaviour
{
    public GameObject[] StatBlocks;
    public PlayerScript player;
    public void AddPlayerHp()
    {
        player = FindAnyObjectByType<PlayerScript>();
        UpdateHpStat();
    }
    private void UpdateHpStat()
    {
        player = FindAnyObjectByType<PlayerScript>();
        if (player.statPoint > 0)
        {
            player.MaxHealth++;
            player.statPoint--;
            StatBlocks[3].GetComponentInChildren<TMP_Text>().text = "Health: " + player.MaxHealth;
        }
        else
        {
            Debug.Log("No stat points to apply");
        }
    }
}
