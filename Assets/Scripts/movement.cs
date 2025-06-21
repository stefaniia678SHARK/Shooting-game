using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    private float speed = 5f;
    private SpriteRenderer spriteRenderer;

    private Vector2 screenBounds;
    private float playerHalfWidth;

    private float xPosLastFrame;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerHalfWidth = spriteRenderer.bounds.extents.x;
      
    }

    private void Update()
    {
        float xDir = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(xDir, 0);
        direction = direction.normalized * 5f * Time.deltaTime; ;
        transform.Translate(direction);

        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;
/*
        FlipCharacterX();*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemybullet"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        } 
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }


    }


    /*    private void FlipCharacterX()
        {
            float input = Input.GetAxis("Horizontal");

            if (input > 0 && (transform.position.x > xPosLastFrame))
            {
                spriteRenderer.flipX = false;
            }
            else if (input < 0 && (transform.position.x < xPosLastFrame))
            {
                spriteRenderer.flipX = true;
            }

            xPosLastFrame = transform.position.x;
        }*/

    /*float xDir = Input.GetAxis("Horizontal");
    float yDir = Input.GetAxis("Vertical");
    Vector3 direction = new Vector3(xDir, yDir, 0);
    direction = direction.normalized *5f* Time.deltaTime; ;
    transform.Translate(direction);*/
}
