using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] [Range(5.0f, 10.0f)] private float _speed;


    private Transform _transform;
    private Vector3 _initialPosition;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _initialPosition = _transform.position;
    }


    private void FixedUpdate()
    {
        if (_initialPosition.x < 0) _transform.position += _speed * Time.fixedDeltaTime * Vector3.right;
        else _transform.position += _speed * Time.fixedDeltaTime * Vector3.left;
    }
}