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

    public void SetTarget(Vector3 pos)
    {
        target = pos;
        isTargetSet = true;
    }
}