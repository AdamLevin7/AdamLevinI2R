using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject projectile;

    [SerializeField] float attackTime;
    private float attackTimer;

    [SerializeField] float moveTime;
    private float moveTimer;

    [SerializeField] float moveSpeed;
    private int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;

        //changes the direction that it moves in every few seconds
        if (moveTimer <= 0) 
        {
            DirectionSwitch();   
        }

        if(attackTimer <= 0)
        {
            attackTimer = attackTime;
            Attack();
        }
    }

    public void Attack() 
    {
        Projectile.FireProjectile(projectile, transform.position, new Vector2(5, 0), false);
        //add stuff for animations here
    }

    public void DirectionSwitch() 
    {
        direction = (int)Random.Range(0, 4);
        moveTimer = moveTime;
        switch (direction)
        {
            case 0:
                rb.velocity = new Vector2(moveSpeed, moveSpeed);
                break;
            case 1:
                rb.velocity = new Vector2(-moveSpeed, moveSpeed);
                break;
            case 2:
                rb.velocity = new Vector2(moveSpeed, -moveSpeed);
                break;
            case 4:
                rb.velocity = new Vector2(-moveSpeed, -moveSpeed);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DirectionSwitch(); //if it bumps into a wall, switch direction
    }
}
