using TMPro.Examples;
using UnityEngine;
using TMPro;
public class AddDefStat : MonoBehaviour
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
            textBlocks.text = "Defense: " + player.defense;
            statPoints.text = "Statpoints: " + player.statPoint;
        }
        else
        {
            string text = "No stat point to apply...";
            textBubble.turnON(text);
        }
    }
}
