using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using Utility;
using Random = UnityEngine.Random;


public class LevelManager : Singleton<LevelManager>
{
    [Header("Fields")] [SerializeField] private Text moneyTextField;
    [SerializeField] private string _moneyBaseText = "Money: ";
    [SerializeField] private Transform[] _spawnPoints;


    [Header("Enemy Prefabs")] [SerializeField]
    private GameObject _kamikazePrefab;

    [SerializeField] private GameObject _planePrefab;

    [Header("Enemy Number")] [SerializeField] [Range(0.0f, 20.0f)]
    private int _numberOfKamikaze;

    [SerializeField] [Range(0.0f, 20.0f)] private int _numberOfPlanes;

    [Header("Initial Game State")] [SerializeField] [Range(100, 250)]
    private int _initialMoney;

    private int _actualMoney;


    private void Start()
    {
        if (_numberOfKamikaze > 0) StartCoroutine(GenerateKamikaze());
        if (_numberOfPlanes > 0) StartCoroutine(GeneratePlanes());


        StartCoroutine(AutoUpdateMoney());

        moneyTextField.text = _moneyBaseText + " " + _initialMoney;
        _actualMoney = _initialMoney;
    }

    private IEnumerator GeneratePlanes()
    {
        for (int i = 0; i < _numberOfPlanes; i++)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(2, 3)];
            Vector3 position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

            GameObject enemyGameObject = Instantiate(_planePrefab, position, Quaternion.identity);
        }
        
        
        yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
    }

    private IEnumerator AutoUpdateMoney()
    {
        while (true)
        {
            UpdatePlayerMoney(3);
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator GenerateKamikaze()
    {
        for (int i = 0; i < _numberOfKamikaze; i++)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, 1)];
            Vector3 position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

            GameObject enemyGameObject = Instantiate(_kamikazePrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
        }
    }

    public void UpdatePlayerMoney(int value)
    {
        _actualMoney += value;
        moneyTextField.text = _moneyBaseText + " " + _actualMoney;
    }
}