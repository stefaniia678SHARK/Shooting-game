using UnityEngine.InputSystem;

using UnityEngine;

public class shooting : MonoBehaviour
{

    public Transform shootingPoint;
    public Transform bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // shoot after space is pressed
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
        
    }
}
