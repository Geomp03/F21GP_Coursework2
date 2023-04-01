using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private AudioClip equip;
    private SoundEffectSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroyed when player collides with it...
        if (collision.gameObject.tag == "Player")
        {
            audioSource.PlaySoundEffect(equip);
            Destroy(gameObject);
        }
    }

    public void SpawnItem()
    {
        gameObject.SetActive(true);
    }
}
