using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the car

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        // Get horizontal input (left or right arrow)
        float moveX = Input.GetAxis("Horizontal");

        // Move the car left or right based on input
        MoveCar(moveX);
    }

    void MoveCar(float moveX)
    {
        // Move the car horizontally (left/right) on the X-axis
        rb.velocity = new Vector3(moveX * moveSpeed, rb.velocity.y, 0f); // No movement in the Z-axis
    }
}
