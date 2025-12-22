using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth <= 0) return;

        // Reduce health and log status
        currentHealth -= damageAmount;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        // Add game over or respawn logic here
    }
}