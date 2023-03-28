using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUp : MonoBehaviour
{
    public PlayerAim playerAim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerAim.fireRate = playerAim.fireRate/2;
            Destroy(gameObject);
        }
    }
}
