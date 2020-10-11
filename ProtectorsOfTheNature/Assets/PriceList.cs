using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PriceList : MonoBehaviour
{
    public price[] prices;

    public int GetPrice(string name)
    {
        return Array.Find(prices, price => price.name == name).cost;
    }
}

[Serializable]
public struct price
{
    public string name;
    public int cost;
}
