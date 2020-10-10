using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparamele : MonoBehaviour
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
        Bullet_Apple bullet = Instantiate(bulletPrefab).GetComponent<Bullet_Apple>();
        //print(target.transform.position == null);
        bullet.SetTarget(target.transform.position);
    }
}
