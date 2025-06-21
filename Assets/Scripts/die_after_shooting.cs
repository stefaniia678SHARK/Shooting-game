using UnityEngine;

public class die_after_shooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet")) //hit the enemy
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // destroy the enemy
        }
    }
}
