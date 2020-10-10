using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Random = UnityEngine.Random;


public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Text moneyTextField;
    [SerializeField] private string _moneyBaseText = "Money: ";


    [Header("Enemy Prefabs")] [SerializeField]
    private GameObject _enemyPrefab;

    [Header("Enemy Number")] [SerializeField] [Range(0.0f, 20.0f)]
    private int _numberOfKamikaze;

    [Header("Initial Game State")] [SerializeField] [Range(100, 250)]
    private int _initialMoney;

    private int _actualMoney;

    private void Start()
    {
        if (_numberOfKamikaze > 0)
        {
            StartCoroutine(GenerateKamikazeEnemy());
        }

        moneyTextField.text = _moneyBaseText + " " + _initialMoney;
        _actualMoney = _initialMoney;
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

    public void UpdatePlayerMoney(int value)
    {
        _actualMoney += value;
        moneyTextField.text = _moneyBaseText + " " + _actualMoney;
    }
}