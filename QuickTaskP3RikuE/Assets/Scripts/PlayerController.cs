using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 5f; // Force applied when the player jumps
    private Rigidbody rb; // Reference to the Rigidbody component
    
    public float slamSpeed = 25f; // Speed of the slam movement
    
    private bool isSlamming = false; // Flag to check if the player is currently slammed

    public float upwardRequirement = 3f; // Minimum upward velocity required to trigger the slam
    public float bounceMultiplier = 1.2f; // Multiplier for the bounce effect after the slam
    public float yRange = -2f;
  
     public bool isGameActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void GameOver()
    {
        isGameActive = false;
        Debug.Log("Game Over!");


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yRange)
        {
            GameOver();
        }
        // Handle player input for movement 
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        
        // Handle player input for jumping
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.F) && !isSlamming)
        {
            StartSlam();
        }
    }
    void StartSlam()
    {
        isSlamming = true;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
    }
    void FixedUpdate()
    {
        if (isSlamming)
        {
            rb.linearVelocity = new Vector3(0, -slamSpeed, 0);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (isSlamming && collision.gameObject.CompareTag("PlatForm"))
        {
            isSlamming = false;
            TriggerSlamImpact();
        }
        if (collision.gameObject.CompareTag("PlatForm"))
        {
            // Bounce the player up after hitting the platform
            Vector3 vel = rb.linearVelocity;
            if (vel.y <=0)
            {
                vel.y = -vel.y;
            }
            vel.y *= bounceMultiplier;
            rb.linearVelocity = vel;
        }
    }
    void TriggerSlamImpact()
    {
        // Implement the logic for what happens when the slam hits the ground
        Debug.Log("Slam impact triggered!");
    }

}
