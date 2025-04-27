using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float reverseBoostMultiplier = 2f;
    public float rotationSpeed = 100f;

    public KeyCode boostKey = KeyCode.LeftShift;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = 1f;

            if (Input.GetKey(boostKey))
            {
                moveDirection *= reverseBoostMultiplier;
            }
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            moveDirection = -1f;
        }

        float rotationInput = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotationInput = -1f;
        }

        
        Vector2 moveVector = transform.up * moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveVector);

     
        float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotationAmount);

    }
}
