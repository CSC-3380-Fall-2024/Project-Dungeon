using TMPro.Examples;
using UnityEngine;
using TMPro;

public class AddHpStat : MonoBehaviour
{
    public TMP_Text textBlocks;
    public TMP_Text statPoints;
    public PlayerScript player;

    private TextBubbleManager textBubble; // Keep track of text bubble

    void Start()
    {
        // Find text bubble canvas
        textBubble = GameObject.Find("TextBubbleCanvas").GetComponent<TextBubbleManager>();

        player = FindAnyObjectByType<PlayerScript>();// Grab the player
    }
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
            player.MaxHealth += 5;

            player.Health = player.MaxHealth;

            player.statPoint--;
            textBlocks.text = "HP/MaxHP: " + player.Health + "/" + player.MaxHealth;
            statPoints.text = "Statpoints: " + player.statPoint;
        }
        else
        {
            string text = "No stat point to apply...";
            textBubble.turnON(text);
        }
    }
}
