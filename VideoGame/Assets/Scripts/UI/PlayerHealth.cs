using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    private TMP_Text healthUI;
    private bool fightCheck;

    void Awake()
    {
        healthUI = GetComponent<TMP_Text>();
        fightCheck = CombatScript.fightCheck;
        healthUI.enabled = fightCheck;

    }

    // Update is called once per frame
    void Update()
    {
        fightCheck = CombatScript.fightCheck;

        if (fightCheck == true)
        {

            healthUI.enabled = fightCheck;

            healthUI.text = "Health: " + PlayerInteract.health;

            transform.position = new Vector2(PlayerInteract.fightPosX, PlayerInteract.fightPosY + 2f);

        }

        else if (fightCheck == false)
        {

            healthUI.enabled = fightCheck;

        }


    }
}
