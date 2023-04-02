using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip uiButton;
    private SoundEffectSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    public void GameButton()
    {
        audioSource.PlaySoundEffect(uiButton);
        SceneManager.LoadScene("GameMap", LoadSceneMode.Single);
        // SceneManager.LoadScene("Dungeon", LoadSceneMode.Single);
    }

    public void SettingsButton()
    {
        // Settings menu maybe...
        Debug.Log("Settings menu");
    }

    public void QuitButton()
    {
        audioSource.PlaySoundEffect(uiButton);
        Application.Quit();
    }
}
