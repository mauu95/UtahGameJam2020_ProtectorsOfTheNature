using UnityEngine.SceneManagement;
using UnityEngine;

public class TowerLayer : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    private Healthbar _healthBarScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _healthBarScript = FindObjectOfType<Healthbar>();
        if (other.CompareTag("KamikazeEnemy"))
        {
            _healthBarScript.TakeDamage(other.GetComponent<PlaneController>().toTowerDamage);
            if (_healthBarScript.health == 0)
            {
                print("You lost bro");
                //SceneManager.LoadScene("GameOver");
            }
        }

        if (other.CompareTag("EnemyPlane"))
        {
            _healthBarScript.TakeDamage(other.GetComponent<PlaneController>().toTowerDamage);
            if (_healthBarScript.health == 0)
            {
                print("You lost bro");
                //SceneManager.LoadScene("GameOver");
            }
        }
    }
}