using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PriceList : MonoBehaviour
{
    public price[] prices;
}

[Serializable]
public struct price
{
    public string name;
    public int cost;
}
