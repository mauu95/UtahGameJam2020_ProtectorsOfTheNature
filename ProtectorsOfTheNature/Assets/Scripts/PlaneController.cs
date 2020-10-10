using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] [Range(5.0f, 10.0f)] private float _speed;
    private GameObject _towerLayerOnTop;

    private Transform _transform;
    private Vector3 _initialPosition;
    private Tower _tower;


    private void Awake()
    {
        _tower = _towerLayerOnTop.GetComponent<Tower>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _initialPosition = _transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 toTarget = _towerLayerOnTop.gameObject.transform.position - transform.position;

        transform.LookAt(toTarget);
    }
}