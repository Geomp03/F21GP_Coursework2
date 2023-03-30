using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemy_shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    public float shootingRange = 10f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // if the player is within shooting range, shoot
        if (distance <= shootingRange)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}

