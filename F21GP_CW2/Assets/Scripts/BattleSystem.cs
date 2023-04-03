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
    //[SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private ColliderTrigger[] colliderTriggers;

    private State state;

    private void Awake()
    {
        state = State.Idle;
        colliderTriggers = FindObjectsOfType<ColliderTrigger>();
    }


    private void Start()
    {
        
        foreach (ColliderTrigger trigger in colliderTriggers)
        {
            trigger.OnPlayerEnterTrigger += (sender, args) => StartBattle();
        }
    }


    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state == State.Idle)
        {
            ColliderTrigger colliderTrigger = sender as ColliderTrigger;

            if (colliderTrigger != null)
            {
                StartBattle();
                colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
            }
        }
    }


    private void StartBattle()
    {
        Debug.Log("Start Battle");

        FindSpawnPoints();
        Spawn(spawnPoints);
        state = State.Active;
    }



    //Randomly spawn enemies in a random spawn point.
    private void Spawn(List<Transform> spawnPoints)
    {
        foreach(Transform transform in spawnPoints)
        {
            var x = Random.Range(0, spawnPoints.Count - 1);
            var y = Random.Range(0, enemyPrefabs.Length - 1);

            Instantiate(enemyPrefabs[y], spawnPoints[x]);

        }
    }



    private void FindSpawnPoints()
    {
        spawnPoints.Clear(); // clear the list before adding new transforms

        // find all game objects with the "EnemySpawn" tag
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("EnemySpawn");

        // get the transform component of each spawn point and add it to the list
        foreach (GameObject spawnPointObject in spawnPointObjects)
        {
            Transform spawnPointTransform = spawnPointObject.transform;
            spawnPoints.Add(spawnPointTransform);
        }
    }
}
