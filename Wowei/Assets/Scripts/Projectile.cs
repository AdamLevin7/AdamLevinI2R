using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shooter;
    public GameObject target;
    public GameObject obstacle;

    public float speed = 10f;


    private float shooterX;
    private float targetX;
    private float shooterY;
    private float targetY;

    private float dist;
    private float nextX;
    private float nextY;
    private float distX;
    private float distY;
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("shooter");
        target = GameObject.FindGameObjectWithTag("Player");
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");

        targetX = target.transform.position.x;
        targetY = target.transform.position.y;

        distX = shooterX - targetX;
        distY = shooterY - targetY;

        shooterX = shooter.transform.position.x;
        shooterY = shooter.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        
        

        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        nextY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);

        Vector3 movePosition = new Vector3(nextX, nextY, transform.position.z);
        transform.position = movePosition;

        if (transform.position == target.transform.position || transform.position == obstacle.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}