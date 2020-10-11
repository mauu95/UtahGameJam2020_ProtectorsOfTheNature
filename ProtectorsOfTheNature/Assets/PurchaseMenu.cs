using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PurchaseMenu : MonoBehaviour
{
    private TowerLayerSlot currentSlot;
    private PriceList prices;
    private LevelManager inventory;

    private void Start()
    {
        prices = FindObjectOfType<PriceList>();
        inventory = LevelManager.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            gameObject.SetActive(false);
    }

    public void BuyAppleShooter()
    {
        int level = currentSlot.GetAppleShooterLevel();
        int currentMoney = inventory.currentMoney;
        int cost = prices.prices[level].cost;

        if (currentMoney >= cost)
        {
            inventory.UpdatePlayerMoney(-cost);
            currentSlot.EquipAppleShooter();
        }
        else
            print("Not enough money: needed: " + cost + " but owning:" + currentMoney);
    }

    public void BuyShieldShooter()
    {
        int currentMoney = inventory.currentMoney;
        int cost = Array.Find(prices.prices, price => price.name == "shieldShooter").cost;

        if(currentMoney >= cost)
        {
            inventory.UpdatePlayerMoney(-cost);
            currentSlot.EquipShieldShooter();
        }

    }

    public void SetSlot(TowerLayerSlot slot)
    {
        currentSlot = slot;
    }
}
