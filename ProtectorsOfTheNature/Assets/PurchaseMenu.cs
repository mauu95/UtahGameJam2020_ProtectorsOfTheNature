using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PurchaseMenu : MonoBehaviour
{
    private TowerLayerSlot currentSlot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            gameObject.SetActive(false);
    }

    public void BuyAppleShooter()
    {
        currentSlot.EquipAppleShooter();
    }

    public void BuyShieldShooter()
    {
        currentSlot.EquipShieldShooter();
    }

    public void SetSlot(TowerLayerSlot slot)
    {
        currentSlot = slot;
    }
}
