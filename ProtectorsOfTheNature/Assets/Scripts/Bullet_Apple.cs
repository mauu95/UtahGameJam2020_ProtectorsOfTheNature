using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Apple : MonoBehaviour
{
    public float speed = 1f;

    private Vector3 target;
    private bool isTargetSet = false;

    private void Update()
    {
        if (transform.position == target)
            Destroy(gameObject);

        if (isTargetSet)
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KamikazeEnemy"))
        {
            LevelManager.Instance.UpdatePlayerMoney(10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("EnemyPlane"))
        {
            LevelManager.Instance.UpdatePlayerMoney(20);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetTarget(Vector3 pos)
    {
        target = pos;
        isTargetSet = true;
    }
}