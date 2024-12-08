using TMPro.Examples;
using UnityEngine;
using TMPro;

public class AddSpdStat : MonoBehaviour
{
    public GameObject[] StatBlocks;
    public PlayerScript player;
    public void AddPlayerSpd()
    {
        player = FindAnyObjectByType<PlayerScript>();
        UpdateSpdStat();
    }
    private void UpdateSpdStat()
    {
        player = FindAnyObjectByType<PlayerScript>();
        if (player.statPoint > 0)
        {
            player.speed++;
            player.statPoint--;
            StatBlocks[2].GetComponentInChildren<TMP_Text>().text = "Speed: " + player.speed;
        }
        else
        {
            Debug.Log("No stat points to apply");
        }
    }
}
