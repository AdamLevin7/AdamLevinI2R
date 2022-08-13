using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    public Rigidbody2D rb;
    private Animator animator;

    private Vector2 MoveDirection;
    private bool facingRight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInputs();

        if(animator != null)
            animator.SetFloat("Speed", Mathf.Abs((MoveDirection.x) * MoveSpeed) + Mathf.Abs((MoveDirection.y) * MoveSpeed));
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(MoveX, MoveY).normalized;

        if (facingRight == true && MoveX > 0)
        {
            Flip();
        }
        else if (facingRight == false && MoveX < 0)
        {
            Flip();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
