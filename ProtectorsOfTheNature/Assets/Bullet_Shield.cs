using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shield : MonoBehaviour
{
    public GameObject shieldPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
