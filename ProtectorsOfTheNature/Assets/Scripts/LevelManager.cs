using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject _enemyPrefab;
    
    [Header("Enemy Number")]
    [SerializeField] [Range(1.0f, 20.0f)] private int _numberOfKamikaze;

    private void Start()
    {
        StartCoroutine(GenerateKamikazeEnemy());
    }

    private IEnumerator GenerateKamikazeEnemy()
    {
        for (int i = 0; i < _numberOfKamikaze; i++)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Vector3 position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

            GameObject enemyGameObject = Instantiate(_enemyPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }
}