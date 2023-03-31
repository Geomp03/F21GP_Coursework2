using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeedUp : MonoBehaviour
{
    private PlayerAim playerAim;
    private SoundEffectSource audioSource;
    [SerializeField] private AudioClip shootingSpeedUp;

    private void Awake()
    {
        playerAim = FindObjectOfType<PlayerAim>();
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerAim.shootForce = playerAim.shootForce + 5;
            audioSource.PlaySoundEffect(shootingSpeedUp);
            Destroy(gameObject);
        }
    }
}
