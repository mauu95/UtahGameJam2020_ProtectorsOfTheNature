using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerLayerPrefab;
    public TowerLayer layerOnTop;

    public void addLayer()
    {
        GameObject obj = Instantiate(towerLayerPrefab, layerOnTop.transform.position + Vector3.up * 2, Quaternion.identity, transform);
        layerOnTop = obj.GetComponent<TowerLayer>();
    }
}
