using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player; // Reference to the player object
    public Vector3 offset = new Vector3(0, 5, -7); // Offset from the player position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
