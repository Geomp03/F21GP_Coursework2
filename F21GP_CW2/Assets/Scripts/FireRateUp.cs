using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUp : MonoBehaviour
{
    private PlayerAim playerAim;
    private SoundEffectSource audioSource;
    [SerializeField] private AudioClip FireRateUpClip;

    private void Awake()
    {
        playerAim = FindObjectOfType<PlayerAim>();
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerAim.fireRate = playerAim.fireRate / 2;
            audioSource.PlaySoundEffect(FireRateUpClip);
            Destroy(gameObject);
        }
    }
}
