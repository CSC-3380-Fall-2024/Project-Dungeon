using UnityEngine;

public class CombatUI : MonoBehaviour
{

    private Canvas myCanvas;
    private bool fightCheck;

    void Start()
    {
        myCanvas = GetComponent<Canvas>();
        myCanvas.enabled = CombatScript.fightCheck;

    }

    void Update()
    {

        myCanvas.enabled = CombatScript.fightCheck;

    }

}
