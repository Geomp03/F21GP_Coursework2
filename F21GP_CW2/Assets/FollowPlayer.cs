using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Player Player;

    // Update is called once per frame
    void Update()
    {
        // Force camera to follow the player sprite
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -25f);
    }
}
