using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp : MonoBehaviour
{
    private Player player;
    private SoundEffectSource audioSource;
    [SerializeField] private AudioClip HpUpClip;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.currentHealth++;
            audioSource.PlaySoundEffect(HpUpClip);
            Destroy(gameObject);
        }
    }
}
