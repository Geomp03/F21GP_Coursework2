using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBossMusic : MonoBehaviour
{
    private MusicSystem music;
    [SerializeField] private AudioClip bossMusic;

    private void Start()
    {
        music = FindObjectOfType<MusicSystem>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        music.ChangeMusicClip(bossMusic);
    }
}
