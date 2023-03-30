using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform aimStaffEndPointPosition;

    public float shootForce = 10f;
    public float fireRate = 1f;
    private float nextFire = 0f;

    public GameObject bulletPrefab;

    [HideInInspector] public float angle;

    private void Update()
    {
        Aim();
        Shoot();
    }

    private void Aim()
    {
        //Calculate mouse position and set angle to point towards the mouse
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        //Debug.Log(angle);
    }
    private void Shoot()
    {
        // Shooting Colourful bullets
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            // Fire rate counter
            nextFire = Time.time + fireRate;

            Vector3 mousePosition = GetMouseWorldPosition();

            // Instantiate bullet prefab
            GameObject bullet = Instantiate(bulletPrefab, aimStaffEndPointPosition.position, aimStaffEndPointPosition.rotation);

            // Add force to the bullet using its rigid body. Force always points forward from where the character is looking.
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(aimStaffEndPointPosition.up * shootForce, ForceMode2D.Impulse);

            //// Set the starting color of the bullet prefab to the players current colour
            ////SpriteRenderer bulletRend = bullet.GetComponent<SpriteRenderer>();
            ////bulletRend.color = playerRend.color;
        }
           
    }

    //Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
