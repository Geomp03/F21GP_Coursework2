using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    private Player player;
    [SerializeField] float range;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction to the player
        Vector2 direction = player.transform.position - transform.position;

        // Get the angle to rotate towards the player's direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Check if the player is within range
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= range)
        {
            // Apply the rotation
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
