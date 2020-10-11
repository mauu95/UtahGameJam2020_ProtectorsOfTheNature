using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_ShieldShooter : Weapon
{
    public GameObject bulletPrefab;
    public float force = 1f;
    public float shootingFrequency = 10f;

    private void Start()
    {
        InvokeRepeating("shoot", 0f, 10f);
    }

    public void shoot()
    {
        GameObject gm = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = gm.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * force);
    }
}
