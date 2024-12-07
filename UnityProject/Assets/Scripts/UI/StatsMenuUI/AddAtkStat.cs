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
        player.Attack++;
        UpdateAtkStat();
    }
    void UpdateAtkStat()
    {
        StatBlocks[0].GetComponentInChildren<TMP_Text>().text = "Attack: " + player.Attack;
    }
}
