using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    public GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        StartBattle();
    }

    private void StartBattle()
    {
        Debug.Log("Start Battle");
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(enemyPrefab, spawnPoint);
    }
}
