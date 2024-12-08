using TMPro.Examples;
using UnityEngine;
using TMPro;

public class AddAtkStat : MonoBehaviour
{
    public GameObject[] StatBlocks;
    public PlayerScript player;
    public void AddPlayerAtk()
    {
        player = FindAnyObjectByType<PlayerScript>();
        UpdateAtkStat();
    }
    private void UpdateAtkStat()
    {
        player = FindAnyObjectByType<PlayerScript>();
        if (player.statPoint > 0)
        {
            player.Attack++;
            player.statPoint--;
            StatBlocks[0].GetComponentInChildren<TMP_Text>().text = "Attack: " + player.Attack;
        }
        else
        {
            Debug.Log("No stat points to apply");
        }
    }
}
