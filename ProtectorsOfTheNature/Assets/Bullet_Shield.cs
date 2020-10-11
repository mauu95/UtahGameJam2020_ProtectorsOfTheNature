using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shield : MonoBehaviour
{
    public GameObject shieldPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
