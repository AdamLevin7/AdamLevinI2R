using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject projectile;
    [Space]
    public float fireRate = 1;
    [SerializeField] float defaultFireDelay = 3; //the amount of time it takes for the turret to fire when fireRate = 1
    private float fireCooldown;
    [Space]
    public float projectileSpeed = 5;
    
    void Start()
    {
        fireCooldown = GetFireDelay();
    }
    
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown <= 0)
        {
            Fire();
            fireCooldown = GetFireDelay();
        }
    }

    private void Fire()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 velocity = angle.ToDirection() * projectileSpeed;
        Projectile.FireProjectile(projectile, transform.position, velocity, true);
    }

    private float GetFireDelay()
    {
        return defaultFireDelay / fireRate;
    }
}
