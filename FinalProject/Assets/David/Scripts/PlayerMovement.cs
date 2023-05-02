using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int jumpForce;
    public int jumpcount;
    public int maxJumpCount;
    private float moveDirection;
    public float moveSpeed;
    private bool Jumping;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private bool facingRight = true;
    public bool isGrounded;
    public float checkRadious;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }
    private void FixedUpdate()
    {
        ProcessInput();
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }
    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (Jumping)
        {
            Debug.Log("Jumping");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpcount--;
        }
        Jumping = false;
    }

    private void ProcessInput()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpcount > 0)
            Jumping = true;
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

    }
    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 9;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;
    }
 
    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {   
            transform.parent = col.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
