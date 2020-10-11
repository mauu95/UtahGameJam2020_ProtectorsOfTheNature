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
    [SerializeField] private string _moneyBaseText;
    [SerializeField] private Transform[] _spawnPoints;


    [Header("Enemy Prefabs")] [SerializeField]
    private GameObject _kamikazePrefab;

    [SerializeField] private GameObject _planePrefab;

    private int _initialMoney = 10000;

    public int currentMoney { get; set; }

    [Range(0f,1f)]
    public float mobsSpawnSpeed = 0;
    public float maxWait = 2f;



    private void Start()
    {
        StartCoroutine(GenerateKamikaze());
        StartCoroutine(GeneratePlanes());
        StartCoroutine(AutoUpdateMoney());

        moneyTextField.text = _moneyBaseText + " " + _initialMoney;
        currentMoney = _initialMoney;
    }

    private IEnumerator GenerateKamikaze()
    {
        while (true)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, 2)];
            Instantiate(_kamikazePrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(maxWait - (mobsSpawnSpeed * maxWait) + 0.01f);
        }
    }

    private IEnumerator GeneratePlanes()
    {
        while(true)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(2, _spawnPoints.Length)];
            Instantiate(_planePrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(maxWait - (mobsSpawnSpeed * maxWait) + 0.5f);
            // yield return new WaitForSeconds(Random.Range(0.5f, 2.0f) * (100-mobsSpawnSpeed) / 100f);
        }
    }


    private IEnumerator AutoUpdateMoney()
    {
        while (true)
        {
            UpdatePlayerMoney(3);
            yield return new WaitForSeconds(1);
        }
    }

    public void UpdatePlayerMoney(int value)
    {
        currentMoney += value;
        moneyTextField.text = _moneyBaseText + " " + currentMoney;
    }
}