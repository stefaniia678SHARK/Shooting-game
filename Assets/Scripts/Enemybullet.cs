using UnityEngine;

public class Enemybullet : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rb;
    public float force;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player").transform;

        Vector3 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * force;   

  /*      //for rotation a bullet to the enemy
        float rot = Mathf.Atan2(-direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0, 0, rot);*/
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
