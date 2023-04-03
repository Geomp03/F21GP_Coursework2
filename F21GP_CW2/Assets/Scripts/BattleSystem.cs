using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
    }

    public GameObject[] enemyPrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private ColliderTrigger colliderTrigger;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if(state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
        
    }

    private void StartBattle()
    {
        Debug.Log("Start Battle");

        Spawn();
        state = State.Active;
    }

    //Randomly spawn enemies in a random spawn point.
    private void Spawn()
    {
        FindSpawnPoints();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var x = Random.Range(0, spawnPoints.Count - 1);
            var y = Random.Range(0, enemyPrefabs.Length - 1);

            var enemy = Instantiate(enemyPrefabs[y], spawnPoints[x]);

            spawnPoints.RemoveAt(x);
        }
    }

    private void FindSpawnPoints()
    {
        spawnPoints.Clear(); // clear the list before adding new transforms

        // find all game objects with the "SpawnPoint" tag
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("EnemySpawn");

        // get the transform component of each spawn point and add it to the list
        foreach (GameObject spawnPointObject in spawnPointObjects)
        {
            Transform spawnPointTransform = spawnPointObject.transform;
            spawnPoints.Add(spawnPointTransform);
        }
    }
}
