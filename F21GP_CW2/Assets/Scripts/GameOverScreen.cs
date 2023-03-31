using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public PlayerRespawn playerRespawn;
    [SerializeField] private AudioClip uiButton;
    private SoundEffectSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    public void InitializeGameOverScreen()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0; // Freeze game...
    }

    public void RespawnButton()
    {
        audioSource.PlaySoundEffect(uiButton);
        playerRespawn.Respawn();
        gameObject.SetActive(false);
        Time.timeScale = 1; // Unfreeze game...
    }

    public void QuitButton()
    {
        audioSource.PlaySoundEffect(uiButton);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        Debug.Log("Quit game button");
        // Load main menu scene
        Time.timeScale = 1; // Unfreeze game...
    }
}
