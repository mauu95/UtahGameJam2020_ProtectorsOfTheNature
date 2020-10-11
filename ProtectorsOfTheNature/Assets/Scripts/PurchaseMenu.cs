using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseMenu : MonoBehaviour
{
    private TowerLayerSlot currentSlot;
    private PriceList prices;
    private LevelManager inventory;

    public GameObject appleShooterImg;
    public TextMeshProUGUI appleShoterDescription;

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
        int currentMoney = inventory.CurrentMoney;
        int cost = prices.prices[level].cost;

        if (level == 3)
            return;

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
        int currentMoney = inventory.CurrentMoney;
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

        int level = slot.GetAppleShooterLevel();

        if(level == 0)
            appleShoterDescription.text = "200";
        if (level == 1)
            appleShoterDescription.text = "400";
        if (level == 2)
            appleShoterDescription.text = "800";


        appleShooterImg.GetComponent<Image>().sprite = FindObjectOfType<WeaponsManager>().GetAppleShooterSpriteLevel(level);
    }
}
