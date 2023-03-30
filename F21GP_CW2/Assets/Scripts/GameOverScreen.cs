using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public PlayerRespawn playerRespawn;

    public void InitializeGameOverScreen()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0; // Freeze game...
    }

    public void RespawnButton()
    {
        playerRespawn.Respawn();
        gameObject.SetActive(false);
        Time.timeScale = 1; // Unfreeze game...
    }

    public void QuitButton()
    {
        Debug.Log("Quit game button");
        // Load main menu scene
    }
}
