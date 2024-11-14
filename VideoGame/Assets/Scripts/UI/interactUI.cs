using UnityEngine;
using TMPro;

/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/9/2024
 * Description: This is the UI to indicated if the player can interact with something. The indicator should be a floating "E"
 */

public class interactUI : MonoBehaviour
{
    private float posX;
    private float posY;

    private TMP_Text myText;

    void Awake()
    {

        myText = GetComponent<TMP_Text>();
        myText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (CombatScript.distance < 1 && CombatScript.fightCheck == false)
        {
            myText.enabled = true;
            posX = (float)PlayerInteract.posX + 1;
            posY = (float)PlayerInteract.posY + 1;

            transform.position = new Vector2(posX, posY);

        }

        else { myText.enabled = false; }

    }
}
