using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] [Range(2.0f, 10.0f)] private float _speed;

    private Vector3 _initialPosition;
    private Text playerMoneyText;


    // Caching! Use this variable instead of the traditional one.
    private Transform _transform;


    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (_initialPosition.x < 0) _transform.position += _speed * Time.fixedDeltaTime * transform.right;
        else _transform.position += _speed * Time.fixedDeltaTime * -transform.right;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TreeBlock"))
        {
            Destroy(gameObject);
        }
    }
}