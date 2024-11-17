using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform enemy;
    private Vector2 distance;

    public bool FightCheck { get; set; }

    public double Health { get;  set; }
    public double Attack { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = FindAnyObjectByType<EnemyScript>().transform;

        FightCheck = false;

        Attack = 5;
        Health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        distance = enemy.position - transform.position;

        if (distance.magnitude <= 1 && Input.GetKeyUp(KeyCode.E))
        {

            FightCheck = true;

        }
    }
}
