using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{

    [SerializeField] private List<GameObject> roomLoot = new List<GameObject>();

    private int enemyCount;
    private bool lootSpawned = false;
    private Vector3 temp;
    private Vector3 spawnLocation;

    private SoundEffectSource audioSource;
    [SerializeField] private AudioClip lootSFX;


    private void Start()
    {
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    private void Update()
    {
        if (enemyCount == 0 && lootSpawned == false)
        {
            Debug.Log("Room cleared!!");
            for (int i = 0; i < roomLoot.Count; i++)
            {
                temp = Random.insideUnitCircle * 5;
                spawnLocation = transform.position + temp;   // Select a random spot to spot the loot
                Instantiate(roomLoot[i], spawnLocation, Quaternion.identity);  // Spawn loot instance
            }
            audioSource.PlaySoundEffect(lootSFX);
            lootSpawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyCount++;
            Debug.Log(enemyCount);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyCount--;
            Debug.Log(enemyCount);
        }
    }
}
