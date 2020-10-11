using Unity.Mathematics;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] [Range(5.0f, 10.0f)] private float _speed;
    [Range(1.0f, 30.0f)] public float toTowerDamage;
    
    
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _initialPosition;
    private GameObject _topLayer;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _topLayer = FindObjectOfType<Tower>().layerOnTop.gameObject;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _initialPosition = _transform.position;

        if (_initialPosition.x < 0)
        {
            _spriteRenderer.flipY = true;
        }
    }

    private void FixedUpdate()
    {
        _transform.right = _transform.position - _topLayer.transform.position;

        float step = _speed * Time.fixedDeltaTime;
        _transform.position = Vector2.MoveTowards(_transform.position, _topLayer.transform.position, step);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TreeBlock"))
        {
            Destroy(gameObject);
            
            LevelManager.Instance.UpdatePlayerMoney(45);
        }
    }
}