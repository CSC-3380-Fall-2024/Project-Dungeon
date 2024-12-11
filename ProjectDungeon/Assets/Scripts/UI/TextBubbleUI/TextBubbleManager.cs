using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextBubbleManager : MonoBehaviour
{


    /*
     private TextBubbleManager textBubble; // Keep track of text bubble



    // Find text bubble canvas
    textBubble = GameObject.Find("TextBubbleCanvas").GetComponent<TextBubbleManager>();

    */


    // Grab the text
    [SerializeField]
    private TMP_Text textBubble;

    // Grab text background
    [SerializeField]
    private Image textBackground;

    void Awake()
    {
        // Turned off at the start
        textBackground.enabled = false;
        textBubble.enabled = false;

    }

    public void turnON(string input)
    {
            
        
        // Pass input to text bubble function
        StartCoroutine(giveText(input));
        
    }

    IEnumerator giveText( string input)
    {
        // Turn on the text
        textBackground.enabled = true;
        textBubble.enabled = true;

        // Display text
        textBubble.text = input;

        // Wait for a certain amount of time
        yield return new WaitForSeconds(3f);


        // Turn off text
        textBackground.enabled = false;
        textBubble.enabled = false;

    }

}
