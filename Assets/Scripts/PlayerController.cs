/*using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 input;
    private Animator animator;
    private Vector2 lastMoveDirection;
    private Rigidbody2D rb;
    public LayerMask collisionLayer;
    public VectorValue startingPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        transform.position = startingPosition.initialValue;
    }

    private void Update()
    {
        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        if (input.x != 0) input.y = 0;

        bool isMoving = input != Vector2.zero;

        if (isMoving)
        {
            Vector2 moveDirection = input.normalized;

            if (!IsColliding(moveDirection))
            {
                rb.velocity = moveDirection * moveSpeed;
                lastMoveDirection = moveDirection;
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop movement if colliding
                isMoving = false; // Set player to idle state
            }
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop movement when no input
        }

        // Update animation parameters
        animator.SetFloat("moveX", isMoving ? input.x : lastMoveDirection.x);
        animator.SetFloat("moveY", isMoving ? input.y : lastMoveDirection.y);
        animator.SetBool("isMoving", isMoving);
    }

    // BoxCast for better collision detection
    private bool IsColliding(Vector2 direction)
    {
        float distance = moveSpeed * Time.deltaTime;
        Vector2 playerSize = GetComponent<Collider2D>().bounds.extents;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, playerSize, 0, direction, distance, collisionLayer);
        return hit.collider != null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Collided with: " + collision.gameObject.name);
    }
}*/

//for mobile (touchscreen)

/*  Get keyboard or button input (real-time)
moveDirection.x = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right
moveDirection.y = Input.GetAxisRaw("Vertical");    // W/S or Up/Down

if (moveDirection.x != 0) moveDirection.y = 0;

animator.SetFloat("moveX", moveDirection.x);
animator.SetFloat("moveY", moveDirection.y);

//  Apply movement continuously (no 1-unit restriction)
transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime; 
}

/*  UI Buttons (For Mobile Controls)
public void MoveLeft() { moveDirection = Vector2.left; }
public void MoveRight() { moveDirection = Vector2.right; }
public void MoveUp() { moveDirection = Vector2.up; }
public void MoveDown() { moveDirection = Vector2.down; }
public void StopMoving() { moveDirection = Vector2.zero; }  
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    private Animator animator;
    private Rigidbody2D rb;

    public LayerMask collisionLayer;
    public VectorValue startingPosition;

    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        transform.position = startingPosition.initialValue;
    }

    private void Update()
    {
        float keyboardHorizontal = Input.GetAxisRaw("Horizontal");
        float keyboardVertical = Input.GetAxisRaw("Vertical");

        // Combine keyboard and mobile input
        input = new Vector2(horizontalInput + keyboardHorizontal, verticalInput + keyboardVertical);

        // Prevent diagonal
        if (input.x != 0) input.y = 0;

        bool isMoving = input != Vector2.zero;

        if (isMoving)
        {
            Vector2 moveDir = input.normalized;

            if (!IsColliding(moveDir))
            {
                rb.velocity = moveDir * moveSpeed;
                lastMoveDirection = moveDir;
            }
            else
            {
                rb.velocity = Vector2.zero;
                isMoving = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        // Animations
        animator.SetFloat("moveX", isMoving ? input.x : lastMoveDirection.x);
        animator.SetFloat("moveY", isMoving ? input.y : lastMoveDirection.y);
        animator.SetBool("isMoving", isMoving);
    }

    private bool IsColliding(Vector2 direction)
    {
        float distance = moveSpeed * Time.deltaTime;
        Vector2 playerSize = GetComponent<Collider2D>().bounds.extents;
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, playerSize, 0, direction, distance, collisionLayer);
        return hit.collider != null;
    }

    // PointerDown (Hold)
    public void OnMoveUp() => verticalInput = 1;
    public void OnMoveDown() => verticalInput = -1;
    public void OnMoveLeft() => horizontalInput = -1;
    public void OnMoveRight() => horizontalInput = 1;

    // PointerUp (Release)
    public void OnStopVertical() => verticalInput = 0;
    public void OnStopHorizontal() => horizontalInput = 0;
}
