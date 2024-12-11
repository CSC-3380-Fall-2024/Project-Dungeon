using TMPro.Examples;
using UnityEngine;
using TMPro;

public class AddManaStat : MonoBehaviour
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
    public void AddPlayerMana()
    {
        player = FindAnyObjectByType<PlayerScript>();
        UpdateManaStat();
    }
    private void UpdateManaStat()
    {
        player = FindAnyObjectByType<PlayerScript>();
        if (player.statPoint > 0)
        {
            player.MaxMana += 5;

            player.Mana = player.MaxMana;

            player.statPoint--;
            textBlocks.text = "Mana/MaxMana: " + player.Mana + "/" + player.MaxMana;
            statPoints.text = "Statpoints: " + player.statPoint;
        }
        else
        {
            string text = "No stat point to apply...";
            textBubble.turnON(text);
        }
    }
}
