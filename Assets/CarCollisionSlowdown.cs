using UnityEngine;

public class CarCollisionSlowdown : MonoBehaviour
{
    public float slowdownFactor = 0.5f;
    public float slowdownDuration = 1f;

    private bool isSlowed = false;
    private float slowdownTimer = 0f;

    private Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (isSlowed)
        {
            slowdownTimer -= Time.deltaTime;
            if (slowdownTimer <= 0)
            {
                ResetSpeed();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) && !isSlowed)
        {
            ApplySlowdown();
        }
    }

    void ApplySlowdown()
    {
        if (movement != null)
        {
            movement.moveSpeed *= slowdownFactor;
            movement.reverseBoostMultiplier *= slowdownFactor;
            isSlowed = true;
            slowdownTimer = slowdownDuration;
        }
    }

    void ResetSpeed()
    {
        if (movement != null)
        {
            movement.moveSpeed /= slowdownFactor;
            movement.reverseBoostMultiplier /= slowdownFactor;
            isSlowed = false;
        }
    }
}
