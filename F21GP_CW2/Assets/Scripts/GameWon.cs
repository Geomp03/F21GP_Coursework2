using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    public GameWonScreen finishedGame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            finishedGame.InitializeGameWonScreen();
    }
}
