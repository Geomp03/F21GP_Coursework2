using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public Player player;
    public GameObject bullet;

    public Transform bulletPos;
    private float timer;
    [SerializeField] float shootingRange;
    [SerializeField] float shootForce;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            Destroy(gameObject);
    }

    void shoot()
    {
        // Instantiate bullet prefab
        GameObject enemyBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        Vector3 shootdir = bulletPos.position - transform.position;

        Rigidbody2D enemyBulletRB = enemyBullet.GetComponent<Rigidbody2D>();
        enemyBulletRB.AddForce(shootdir * shootForce, ForceMode2D.Impulse);
    }
}

