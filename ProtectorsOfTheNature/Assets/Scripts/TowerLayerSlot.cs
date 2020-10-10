using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLayerSlot : MonoBehaviour
{
    private Weapon[] weapons;

    private bool isEquipped = false;

    private void Start()
    {
        weapons = FindObjectOfType<WeaponsManager>().weapons;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isEquipped)
                return;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.GetComponent<TowerLayerSlot>() != null)
            {
                Instantiate(weapons[0].gameObject, transform);
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
