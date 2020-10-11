using System;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] [Range(5.0f, 10.0f)] private float _speed;

    private Transform _transform;

    private Vector3 _initialPosition;
    private GameObject _topLayer;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _topLayer = FindObjectOfType<Tower>().layerOnTop.gameObject;
    }

    private void Start()
    {
        _initialPosition = _transform.position;
    }

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(_topLayer.transform.position - _transform.position,
            _transform.TransformDirection(Vector3.up));
        _transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);


        float step = _speed * Time.fixedDeltaTime;
        _transform.position = Vector3.MoveTowards(_transform.position, _topLayer.transform.position, step);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TreeBlock"))
        {
            Destroy(gameObject);
        }
    }
}