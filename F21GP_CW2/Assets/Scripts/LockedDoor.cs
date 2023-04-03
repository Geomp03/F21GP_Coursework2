using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private KeyScript keyScript;

    // Start is called before the first frame update
    void Awake()
    {
        keyScript = FindObjectOfType<KeyScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Check for key before "opening" the door
            if (keyScript.holdingKey)
                Destroy(gameObject);

            keyScript.UseKey();
        }
    }
}
