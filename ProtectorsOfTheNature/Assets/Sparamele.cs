using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparamele : Weapon
{
    public GameObject bulletPrefab;
    public Enemy target;
    public float shootingFrequency = 1.0f;

    private void Start()
    {
        InvokeRepeating("Fire", 1.0f, shootingFrequency);
    }

    private void Fire()
    {
        GameObject gm = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet_Apple bullet = gm.GetComponent<Bullet_Apple>();
        bullet.SetTarget(Vector3.zero);
    }
}
