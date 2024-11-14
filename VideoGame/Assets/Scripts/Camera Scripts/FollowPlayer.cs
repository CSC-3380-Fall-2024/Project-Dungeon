using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 fightPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        fightPos = new Vector3(0, 0, -10f);


    }

    // Update is called once per frame
    void Update()
    {

        
        if (CombatScript.fightCheck == false)
        {
            transform.position = new Vector3((float)PlayerInteract.posX, (float)PlayerInteract.posY, -10f);
        }
        else if (CombatScript.fightCheck == true)
        {
            transform.position = fightPos;
        }
    }
}
