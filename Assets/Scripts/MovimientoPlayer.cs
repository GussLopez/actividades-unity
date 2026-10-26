using System;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float speed = 5f;

    public float jumpForce = 4f;
    private float move;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        
        rigidbody2D.linearVelocity = new Vector2(move * speed, rigidbody2D.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
