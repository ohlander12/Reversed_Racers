using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public bool isPlayer = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Sikrer at health ikke går under 0
        Debug.Log($"{gameObject.name} took {amount} damage. Remaining: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Sikrer at health ikke overstiger max
        Debug.Log($"{gameObject.name} healed {amount}. Current Health: {currentHealth}");
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} died!");

        if (isPlayer)
        {
            // Restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // Just destroy the enemy
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            TakeDamage(1); // Damage from spikes
        }
        else if (other.CompareTag("Bolt"))
        {
            Heal(1); // Heal when picking up a Bolt
            Destroy(other.gameObject); // Remove the Bolt after picking it up
        }
    }
}
