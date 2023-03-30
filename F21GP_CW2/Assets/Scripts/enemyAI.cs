using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 1f;
    public Transform enemy_graphics;
    Path path;
    int CurrentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    public float detectionDistance = 10f;
    void Start()
    {
        seeker= GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
       // seeker.StartPath(rb.position, target.position, OnPathComplete);
        
    }
    void UpdatePath()
    {
        if (Vector2.Distance(rb.position, target.position) < detectionDistance)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //make bot move
        if (path == null)
            return;
        if(CurrentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath= true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[CurrentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[CurrentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            CurrentWaypoint++;
        }
        
        //make graphics rotate
        if (rb.velocity.x >= 0.01f)
        {
            enemy_graphics.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            enemy_graphics.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
