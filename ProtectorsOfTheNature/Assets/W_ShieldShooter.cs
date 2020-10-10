using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_ShieldShooter : Weapon
{
    public GameObject bulletPrefab;
    public float force = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                GameObject gm = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody2D rb = gm.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.right * force);
            }
        }
    }
}
