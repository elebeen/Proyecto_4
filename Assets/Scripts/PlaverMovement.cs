using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaverMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public Rigidbody2D rb; // Rigidbody2D component for physics interactions
    public PlayerInput playerInput; // PlayerInput component for handling input
    public Vector2 moveInput; // Variable to store the input value
    public Animator animator; // Animator component for handling animations
    public int faceDirection = 1; // Variable to store the direction the player is facing

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    // You can add any additional logic here if needed
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>(); // Read the input value from the PlayerInput component
        Debug.Log(moveInput); // Log the input value to the console for debugging
        animator.SetFloat("horizontal", Mathf.Abs(moveInput.x)); // Set the MoveX parameter in the animator to the x component of moveInput
        animator.SetFloat("vertical", Mathf.Abs(moveInput.y)); // Set the MoveY parameter in the animator to the y component of moveInput

        if (moveInput.x > 0 && transform.localScale.x < 0 || moveInput.x < 0 && transform.localScale.x > 0)
        {
            FlipTool(); // Call the FlipTool method to flip the player sprite
        }

        Debug.Log(moveInput.x); // Log the x component of moveInput to the console for debugging
        Debug.Log(moveInput.y); // Log the y component of moveInput to the console for debugging
        Debug.Log(animator); // Log the entire animator vector to the console for debugging
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        rb.linearVelocity =  new Vector2(moveInput.x, moveInput.y) * speed; // Set the velocity of the Rigidbody2D based on input and speed
    }
    private void FlipTool()
    {
        faceDirection *= -1; // Reverse the face direction
        transform.localScale = new Vector3(faceDirection, transform.localScale.y, transform.localScale.z); // Flip the player sprite by changing its scale
    }
}       
