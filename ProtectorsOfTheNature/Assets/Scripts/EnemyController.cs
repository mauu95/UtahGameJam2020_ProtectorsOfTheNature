using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] [Range(2.0f, 10.0f)] private float _speed;
    [Range(1.0f, 30.0f)] public float toTowerDamage;
    [SerializeField] [Range(1.0f, 100.0f)] private int _moneyDrop;

    private Vector3 _initialPosition;
    private Text playerMoneyText;


    // Caching! Use this variable instead of the traditional one.
    private Transform _transform;
    private Healthbar _healthBarScript;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _healthBarScript = FindObjectOfType<Healthbar>();
    }

    private void Start()
    {
        _initialPosition = transform.position;
        StartCoroutine(PlayKamikazeScream());
    }

    private IEnumerator PlayKamikazeScream()
    {
        AudioManager.Instance.PlayKamikazeVoice();
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
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
            AudioManager.Instance.PlayKamikazeDeath();

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