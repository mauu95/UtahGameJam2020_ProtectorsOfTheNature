using UnityEngine.SceneManagement;
using UnityEngine;

public class TowerLayer : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    private Healthbar _healthBarScript;

    private void Awake()
    {
        _healthBarScript = _healthBar.GetComponent<Healthbar>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KamikazeEnemy"))
        {
            _healthBarScript.TakeDamage(20);
            if (_healthBarScript.health == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}