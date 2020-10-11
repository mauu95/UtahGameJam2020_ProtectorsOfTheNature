using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour
{
    [SerializeField] [Range(5.0f, 10.0f)] private float _speed;
    [SerializeField] [Range(1.0f, 100.0f)] private int _moneyDrop;
    [Range(1.0f, 30.0f)] public float toTowerDamage;


    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _initialPosition;
    private GameObject _topLayer;
    private Healthbar _healthBarScript;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _topLayer = FindObjectOfType<Tower>().layerOnTop.gameObject;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _healthBarScript = FindObjectOfType<Healthbar>();
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
            AudioManager.Instance.PlayExplosion();

            _healthBarScript.TakeDamage(toTowerDamage);
            if (_healthBarScript.health == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            LevelManager.Instance.UpdatePlayerMoney(_moneyDrop);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}