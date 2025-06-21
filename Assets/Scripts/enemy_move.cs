using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Transform target;

    //moves to the enemy it is its aim
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

}
