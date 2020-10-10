using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLayerSlot : MonoBehaviour
{
    private Weapon[] weapons;

    private bool isEquipped = false;
    private Weapon Equipped;

    private void Start()
    {
        weapons = FindObjectOfType<WeaponsManager>().weapons;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<TowerLayerSlot>() != null && hit.collider.gameObject == gameObject)
            {
                if(Equipped == null)
                {
                    Equipped = Instantiate(weapons[0].gameObject, transform).GetComponent<Weapon>();
                    GetComponent<SpriteRenderer>().enabled = false;
                    return;
                }
                    

                Sparamele sparamele = Equipped.GetComponent<Sparamele>();
                if (sparamele.level == 1)
                {
                    Destroy(Equipped.gameObject);
                    Equipped = Instantiate(weapons[1].gameObject, transform).GetComponent<Weapon>();
                }
                else if (sparamele.level == 2)
                {
                    Destroy(Equipped.gameObject);
                    Equipped = Instantiate(weapons[2].gameObject, transform).GetComponent<Weapon>();
                }

                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
