using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering;

public class TowerLayerSlot : MonoBehaviour
{
    private Weapon[] weapons;
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
                PurchaseMenu menu = Resources.FindObjectsOfTypeAll<PurchaseMenu>()[0];
                menu.SetSlot(this);
                menu.gameObject.transform.position = Input.mousePosition;
                menu.gameObject.SetActive(true);
            }
        }
    }

    public void EquipAppleShooter()
    {
        int sparameleLevel = GetAppleShooterLevel();

        if(Equipped)
            Destroy(Equipped.gameObject);

        Equipped = Instantiate(weapons[sparameleLevel + 1].gameObject, transform).GetComponent<Weapon>();

        GetComponent<SpriteRenderer>().enabled = false;

    }

    public void EquipShieldShooter()
    {
        if (Equipped)
            Destroy(Equipped.gameObject);

        Equipped = Instantiate(weapons[0].gameObject, transform).GetComponent<Weapon>();

        GetComponent<SpriteRenderer>().enabled = false;
    }

    public int GetAppleShooterLevel()
    {
        int sparameleLevel;

        if (Equipped == null)
            sparameleLevel = 0;
        else
        {
            Sparamele prevSparamele = Equipped.GetComponent<Sparamele>();
            if (prevSparamele == null)
                sparameleLevel = 0;
            else
                sparameleLevel = prevSparamele.level;
        }

        return sparameleLevel;
    }
}
