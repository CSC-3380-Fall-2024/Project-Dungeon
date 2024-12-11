using TMPro.Examples;
using UnityEngine;
using TMPro;

public class AddAtkStat : MonoBehaviour
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
            textBlocks.text = "Attack: " + player.Attack;
            statPoints.text = "Statpoints: " + player.statPoint;
        }
        else
        {
            string text = "No stat point to apply...";
            textBubble.turnON(text);
        }
    }
}
