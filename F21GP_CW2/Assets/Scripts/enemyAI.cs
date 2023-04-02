using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Player player;
    public Transform enemyGraphics;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Path path;

    [SerializeField] float speed;
    [SerializeField] float detectionDistance;

    private float nextWaypointDistance = 1f;
    private int CurrentWaypoint = 0;
    private bool reachedEndOfPath = false;
    private Transform target;

    public float stopDistance = 3f; // New variable for stopping distance
    public float minDistance = 3f; // New variable for minimum distance

    void Start()
    {
        player = FindObjectOfType<Player>();
        target = player.transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
       // seeker.StartPath(rb.position, target.position, OnPathComplete);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate distance between enemy and player
        float distanceToPlayer = Vector2.Distance(rb.position, target.position);

        // Move away from player if too close
        if (distanceToPlayer < minDistance && name.Contains("Shooter"))
        {
            Vector2 direction = ((Vector2)rb.position - (Vector2)target.position).normalized;
            Vector2 force = direction * speed;
            rb.AddForce(force);
        }

        // Stop moving if enemy is close enough to player
        else if (distanceToPlayer <= stopDistance && name.Contains("Shooter"))
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Move towards player
        else
        {
            // make AI move
            if (path == null)
                return;
            if (CurrentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[CurrentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed; //* Time.deltaTime;
            rb.AddForce(force);

            // Player detection
            float distance = Vector2.Distance(rb.position, path.vectorPath[CurrentWaypoint]);
            if (distance < nextWaypointDistance)
            {
                CurrentWaypoint++;
            }
        }
        // Make graphics rotate
        if (rb.velocity.x >= 0.01f)
        {
            enemyGraphics.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemyGraphics.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            Destroy(gameObject);
    }

    private void UpdatePath()
    {
        if (Vector2.Distance(rb.position, target.position) < detectionDistance)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWaypoint = 0;
        }
    }
}