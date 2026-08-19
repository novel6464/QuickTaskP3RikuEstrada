using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 5f; // Force applied when the player jumps
    private Rigidbody rb; // Reference to the Rigidbody2D component
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player input for movement 
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        
        // Handle player input for jumping
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }
}
