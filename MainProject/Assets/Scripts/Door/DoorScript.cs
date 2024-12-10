using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private PlayerScript player; //Keep track of player

    private Vector2 distance; // Keep track of distance between door and player

    private EnemyScript[] enemy;// Grab a list of all enemies

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find player
        player = FindAnyObjectByType<PlayerScript>();
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None); // Find all enemies

    }

    // Update is called once per frame
    void Update()
    {
        enemy = FindObjectsByType<EnemyScript>(FindObjectsSortMode.None); //Update list of enemies

        // Update distance between door and player
        distance = player.transform.position - transform.position;

        // If very close and the player press "E":
        if (distance.magnitude <= 2 && Input.GetKeyUp(KeyCode.E) && player.level >= 2)
        {
            Destroy(this.gameObject);

        }

    }
}
