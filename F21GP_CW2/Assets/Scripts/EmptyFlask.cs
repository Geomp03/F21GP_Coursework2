using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFlask : MonoBehaviour
{
    [SerializeField] private AudioClip pickUpFlask;
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
            audioSource.PlaySoundEffect(pickUpFlask);
            Destroy(gameObject);
        }
    }

    public void SpawnPotion()
    {
        gameObject.SetActive(true);
    }
}
