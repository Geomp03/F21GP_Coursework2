using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBossMusic : MonoBehaviour
{
    private MusicSystem music;
    [SerializeField] private bool changeMusic;
    [SerializeField] private AudioClip bossMusic;

    private void Start()
    {
        music = FindObjectOfType<MusicSystem>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (changeMusic)
            music.ChangeMusicClip(bossMusic);
    }
}
