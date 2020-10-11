using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparamele : Weapon
{
    public GameObject bulletPrefab;
    public Enemy target;
    public float shootingFrequency = 1.0f;
    public int level = 1;

    private void Start()
    {
        InvokeRepeating(nameof(Fire), 0f, shootingFrequency);
    }

    private void Fire()
    {
        Enemy enemy = FindObjectOfType<Enemy>();


        if (enemy == null)
            return;

        GameObject gm = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet_Apple bullet = gm.GetComponent<Bullet_Apple>();


        bullet.SetTarget(enemy.gameObject.transform.position);
    }
}