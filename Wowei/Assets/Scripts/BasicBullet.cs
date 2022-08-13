using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Projectile
{
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    protected override void OnObstacleHit(Collider2D collider)
    {
        base.OnObstacleHit(collider);
        Debug.Log("Bullet hit obstacle");
    }

    protected override void OnTargetHit(Collider2D collider)
    {
        base.OnTargetHit(collider);
        Debug.Log("Bullet hit target");
    }
}
