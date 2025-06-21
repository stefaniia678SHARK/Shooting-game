using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Transform bullet;
    public Transform shootingPoint;

    public HealthBar healthBar;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  /*      // for the health bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);*/
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate (bullet, shootingPoint.position, Quaternion.identity);
    }

}
