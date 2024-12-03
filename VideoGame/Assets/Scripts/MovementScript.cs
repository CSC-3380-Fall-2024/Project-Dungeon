using UnityEngine;

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main
/*
 * Author: Ryan Tin Tran
 * Last Updated: 11/7/2024
 * Description: Enables movement for the player
 */

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
>>>>>>> fa35998509d94b61d70a067ed67e63e7cdfa30bb
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main
public class MovementScript : MonoBehaviour
{
    // Public variables
    private float walkSpeed = 5f; // How fast we want the player to move
    private float runSpeed = 10f; // How fast the player moves when he runs
    private Rigidbody2D rb; // Variable to hold the player's Rigidbody2D
    private Vector2 movement; // The direction the player is moving

    void Start()
    {
        // Grab the component Rigidbody2D from the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Grabs a number between -1 and 1 when the player presses "a" (left) or "d" (right)
        float verticalInput = Input.GetAxisRaw("Vertical");// Grabs a number between -1 and 1 when the player presses "w" (up) or "s" (down)
        movement = new Vector2(horizontalInput, verticalInput); // Insert the inputs into movement
    }
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> fa35998509d94b61d70a067ed67e63e7cdfa30bb
>>>>>>> 6b9f0ad5c13fec5f820d8b96588c86800845d673
>>>>>>> main
>>>>>>> main
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            rb.linearVelocity = movement * runSpeed; // If the player is holding down left shift, the player will run

        }
        else 
        {

            rb.linearVelocity = movement * walkSpeed; // Otherwise the player will walk

        }
    }
}
