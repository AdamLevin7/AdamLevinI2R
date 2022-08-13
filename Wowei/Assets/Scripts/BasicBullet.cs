using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [SerializeField] float lifetime;
    [SerializeField] float speed;
    [SerializeField] PlayerMovement player;
    [SerializeField] Rigidbody2D bullet;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, lifetime);
        player = FindObjectOfType<PlayerMovement>();
        bullet.MovePosition(player.rb.position);

    }
}
