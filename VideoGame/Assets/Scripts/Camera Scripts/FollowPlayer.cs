using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 fightPos;

    private PlayerScript player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        fightPos = new Vector3(0, 0, -10f);

        player = FindAnyObjectByType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        
        if (player.FightCheck == false)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        }
        else if (player.FightCheck == true)
        {
            transform.position = fightPos;
        }
    }
}
