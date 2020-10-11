using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int health = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            AudioManager.Instance.PlayKamikazeDeath();
            Destroy(collision.gameObject);
            health--;
        }

        if (health <= 0)
            Destroy(gameObject);
    }
}
