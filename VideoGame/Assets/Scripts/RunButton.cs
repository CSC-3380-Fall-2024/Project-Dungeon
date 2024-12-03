using UnityEngine;

public class RunButton : MonoBehaviour
{
    public void run()
    {

        //Disengage
        CombatScript.fightCheck = false;

        CombatScript.movement.enabled = true;
        Debug.Log("Disengage Combat");

    }
}
