using TMPro.Examples;
using UnityEngine;
using TMPro;
public class AddDefStat : MonoBehaviour
{
    public GameObject[] StatBlocks;
    public PlayerScript player;
    public void AddPlayerDef()
    {
        player = FindAnyObjectByType<PlayerScript>();
        UpdateDefStat();
    }
    private void UpdateDefStat()
    {
        player = FindAnyObjectByType<PlayerScript>();
        if (player.statPoint > 0)
        {
            player.defense++;
            player.statPoint--;
            StatBlocks[1].GetComponentInChildren<TMP_Text>().text = "Defense: " + player.defense;
        }
        else
        {
            Debug.Log("No stat points to apply");
        }
    }
}
