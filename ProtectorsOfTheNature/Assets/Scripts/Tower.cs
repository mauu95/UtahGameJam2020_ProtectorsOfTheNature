using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject towerLayerPrefab;
    public TowerLayer layerOnTop;

    [SerializeField] [Range(1, 6)] private int maxLayer;
    private int _actualLayer = 1;


    public void AddLayer()
    {
        if (_actualLayer < maxLayer)
        {
            GameObject obj = Instantiate(towerLayerPrefab, layerOnTop.transform.position + Vector3.up * 2,
                Quaternion.identity, transform);
            layerOnTop = obj.GetComponent<TowerLayer>();
            _actualLayer++;
        }
    }
}