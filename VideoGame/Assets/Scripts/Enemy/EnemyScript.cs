using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform player;
    private Vector2 distance;

    public bool FightCheck { get; set; }

    public double Health { get;  set; }
    public double Attack { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>().transform;

        FightCheck = false;

        Attack = 1;
        Health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.position - transform.position;

        if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E))
        {

            FightCheck = true;

        }
    }
}
