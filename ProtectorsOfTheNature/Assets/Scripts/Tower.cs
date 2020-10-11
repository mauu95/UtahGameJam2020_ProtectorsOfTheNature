using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerLayerPrefab;
    public TowerLayer layerOnTop;

    private int _maxLayer = 4;
    private int _actualLayer = 1;


    public void AddLayer()
    {
        LevelManager inventory = LevelManager.Instance;

        int currentMoney = inventory.currentMoney;
        int cost = FindObjectOfType<PriceList>().GetPrice("addLayer");

        if (currentMoney >= cost && !MaxTreeReached())
        {
            inventory.UpdatePlayerMoney(-cost);
            GameObject obj = Instantiate(towerLayerPrefab, layerOnTop.transform.position + Vector3.up * 2,
                Quaternion.identity, transform);
            layerOnTop = obj.GetComponent<TowerLayer>();
            _actualLayer++;
        }
    }

    public bool MaxTreeReached()
    {
        return _actualLayer >= _maxLayer;
    }
}