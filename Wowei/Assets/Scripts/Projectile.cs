using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    [HideInInspector] new public Rigidbody2D rigidbody;
    public bool targetEnemy;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTargetHit(Collider2D collider)
    {
        Debug.Log($"Hit Target {collider.gameObject.name}");
        Destroy(gameObject);
    }

    protected virtual void OnObstacleHit(Collider2D collider)
    {
        Debug.Log($"Hit Obstacle {collider.gameObject.name}");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            OnObstacleHit(collision);
            return;
        }
        if(targetEnemy)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                OnTargetHit(collision);
            }
        }
        else
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                OnTargetHit(collision);
            }
        }
    }

    public static Projectile FireProjectile(GameObject projectileObject, Vector2 origin, Vector2 velocity, bool targetEnemy)
    {
        Projectile newProjectile = Instantiate(projectileObject).GetComponent<Projectile>();
        newProjectile.transform.position = origin;
        newProjectile.rigidbody.velocity = velocity;
        newProjectile.targetEnemy = targetEnemy;
        return newProjectile;
    }
}