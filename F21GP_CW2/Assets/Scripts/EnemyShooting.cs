using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Player player;
    public GameObject enemyBulletPrefab;
    public Transform bulletPos;
    private SoundEffectSource audioSource;

    [SerializeField] float shootForce = 10f;
    [SerializeField] float shootingRange = 10f;
    private float timer;

    [SerializeField] private AudioClip enemyShotSFX;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        audioSource = FindObjectOfType<SoundEffectSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // If the player is within shooting range, shoot
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
        // Instantiate bullet prefab
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, bulletPos.position, Quaternion.identity);

        // Create a direction vector from the enemy to the player
        Vector3 direction = player.transform.position - bulletPos.transform.position;

        // Add force to the bullet using its rigid body. Force goes along the direction vector created.
        Rigidbody2D enemyBulletRB = enemyBullet.GetComponent<Rigidbody2D>();
        enemyBulletRB.AddForce(direction * shootForce, ForceMode2D.Impulse);
        
        // Rotate bullet accordingly...
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        enemyBullet.transform.rotation = Quaternion.Euler(0, 0, rot);

        // Shooting SFX
        audioSource.PlaySoundEffect(enemyShotSFX);
    }
}

