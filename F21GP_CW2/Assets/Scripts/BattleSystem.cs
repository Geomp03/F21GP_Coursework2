using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active
    }

    public GameObject[] enemyPrefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private ColliderTrigger colliderTrigger;
    //[SerializeField] private ColliderTrigger[] colliderTriggers;

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
        if (state == State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
    }


    private void StartBattle()
    {
        Debug.Log("Start Battle");

        FindSpawnPoints();
        Spawn(spawnPoints);
        //state = State.Active;
    }



    //Randomly spawn enemies in a random spawn point.
    private void Spawn(List<Transform> spawnPoints)
    {
        Debug.Log("Trying to spawn...");
        foreach (Transform transform in spawnPoints)
        {
            Debug.Log("Spawning enemy!");
            var y = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[y], transform.position, transform.rotation);
        }
    }




    private void FindSpawnPoints()
    {
        Debug.Log("Finding spawn points...");
        //spawnPoints.Clear(); // clear the list before adding new transforms

        // find all game objects with the "EnemySpawn" tag
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("EnemySpawn");

        // get the transform component of each spawn point and add it to the list
        foreach (GameObject spawnPointObject in spawnPointObjects)
        {
            Transform spawnPointTransform = spawnPointObject.transform;
            Debug.Log("In foreach loop, adding spawnpointobject in spawnpoints");
            spawnPoints.Add(spawnPointTransform);
        }
    }
}
