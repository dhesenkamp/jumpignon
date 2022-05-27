using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    // Variables
    private Vector3 startPosition = new (0f, 0f, 0f);
    private float movementSpeed = 5f;
    private float jumpSpeed = 10f;
    private float firingCooldown = 0.5f;
    private float nextFiringTime = 0f;
    
    [SerializeField] private Rigidbody body;
    [SerializeField] private GameObject projectilePrefab;
    
    
    void Start()
    {
        // Set start position
        transform.position = startPosition;
    }
    
    void Update()
    {
        PlayerMovement();
        
        // Shoot projectile
        if (Input.GetKeyDown(KeyCode.E) && nextFiringTime < Time.time)
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            nextFiringTime = Time.time + firingCooldown;
        }
    }

    void PlayerMovement()
    {
        // Set bottom boundary, respawn if crossed
        if (transform.position.y < -5)
        {
            transform.position = startPosition;
        }
        
        // Horizontal movement via key input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Time.deltaTime * movementSpeed * horizontalInput * Vector3.right);

        // Upwards movement (jumping) on space bar key press
        // Constraint: only allow movement once previous jump has finished
        if (Input.GetKeyDown(KeyCode.Space) && body.velocity.y == 0)
        {
            body.velocity += new Vector3(0f, jumpSpeed, 0f);
        }

        // Same as above but with time delay
        // Requires instantiation of nextJumpTime & jumpCooldown
        /*if (Input.GetKeyDown("space") && nextJumpTime <= Time.time)
        {
            body.velocity += new Vector3(0f, _jumpSpeed, 0f);
            nextJumpTime = Time.time + jumpCooldown;
        }*/
    }
}