using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float zrotationSpeed = 100f; // Speed of rotation in degrees per second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the obstacle around its Z-axis
        transform.Rotate(Vector3.forward, zrotationSpeed * Time.deltaTime);
    }
}
