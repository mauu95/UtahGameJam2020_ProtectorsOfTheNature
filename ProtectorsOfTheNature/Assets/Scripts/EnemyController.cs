using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class EnemyController : MonoBehaviour
{
    [SerializeField] [Range(2.0f, 10.0f)] private float _speed;

    private Vector3 initialPosition;

    // Caching! Use this variable instead of the traditional one.
    private Transform _transform;


    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (initialPosition.x < 0)
        {
            _transform.position += _speed * Time.fixedDeltaTime * transform.right;
        }
        else _transform.position += _speed * Time.fixedDeltaTime * -transform.right;
    }
}