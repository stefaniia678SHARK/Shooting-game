using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;  // Reference to the HealthBar


    
    private void Start()
    { 

        currentHealth = maxHealth;
        
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);  // Set max health on the health bar
            healthBar.gameObject.SetActive(true);
        }

  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Reduce health when hit by player bullet
            TakeDamage(10); // Example damage value
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);  // Update health bar with new health
        }

        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(false); 
        }
        // Handle death (e.g., play animation, destroy enemy, etc.)
        Destroy(gameObject);  // For example, destroy the enemy when health reaches 0
    }
}
