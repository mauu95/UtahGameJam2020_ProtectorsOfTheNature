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


    [Header("Enemy Prefabs")]
    [SerializeField]
    private GameObject _kamikazePrefab;

    [SerializeField] private GameObject _planePrefab;

    private int _initialMoney = 500;

    public int currentMoney { get; set; }

    [Range(0f, 1f)]
    public float mobsSpawnSpeed = 0;
    public float maxWait = 2f;

    public float timeToNextLevel = 3f;

    private float x;

    private void Start()
    {
        StartCoroutine(GenerateKamikaze());
        StartCoroutine(GeneratePlanes());
        StartCoroutine(AutoUpdateMoney());
        StartCoroutine(AutoUpdateMobsSpawnSpeed());

        moneyTextField.text = _moneyBaseText + " " + _initialMoney;
        currentMoney = _initialMoney;
        x = 0;

    }

    private IEnumerator AutoUpdateMobsSpawnSpeed()
    {
        while (mobsSpawnSpeed < 1f)
        {
            x += 0.1f;
            mobsSpawnSpeed = x * x;
            yield return new WaitForSeconds(timeToNextLevel);
        }

        yield return new WaitForSeconds(timeToNextLevel);

        print("you win");
    }

    private IEnumerator GenerateKamikaze()
    {
        while (true)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, 2)];
            Instantiate(_kamikazePrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(maxWait - (mobsSpawnSpeed * maxWait) + 0.1f);
        }
    }

    private IEnumerator GeneratePlanes()
    {
        while (true)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(2, _spawnPoints.Length)];
            Instantiate(_planePrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(maxWait - (mobsSpawnSpeed * maxWait) + 0.5f);
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