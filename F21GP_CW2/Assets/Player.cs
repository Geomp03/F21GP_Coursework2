using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxcol;
    private Rigidbody2D rb;
    private SpriteRenderer rend;

    [SerializeField] float speed;
    private float DirX, DirY;
    [SerializeField] private string TempColour, BaseColour = "Default";
    

    // Start is called before the first frame update
    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        DirX = Input.GetAxis("Horizontal");
        DirY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(DirX * speed, DirY * speed);

        // Handle colour changes
        ColourEval();
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug info
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        // On entering a colour puddle set TempColour to the appropriate colour.
        if (col.gameObject.name == "BluePuddle")
            TempColour = "Blue";
        else if (col.gameObject.name == "RedPuddle")
            TempColour = "Red";
        else if (col.gameObject.name == "YellowPuddle")
            TempColour = "Yellow";
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // After leaving a colour puddle return TempColour to "default".
        if (col.gameObject.name == "BluePuddle" || col.gameObject.name == "RedPuddle" || col.gameObject.name == "YellowPuddle")
            TempColour = "Default";
    }

    private void ColourEval()
    {
        switch(BaseColour)
        {
            case "Default":
                switch(TempColour)
                {
                    case "Blue":
                        rend.color = Color.blue;
                        break;
                    case "Red":
                        rend.color = Color.red;
                        break;
                    case "Yellow":
                        rend.color = Color.yellow;
                        break;
                    default:
                        rend.color = Color.black;
                        break;
                }
                break;
            case "Blue":
                switch (TempColour)
                {
                    case "Blue":
                        rend.color = Color.blue;
                        break;
                    case "Red":
                        rend.color = Color.red;
                        break;
                    case "Yellow":
                        rend.color = Color.yellow;
                        break;
                    default:
                        rend.color = Color.black;
                        break;
                }
                break;
            case "Yellow":
                switch (TempColour)
                {
                    case "Blue":
                        rend.color = Color.blue;
                        break;
                    case "Red":
                        rend.color = Color.red;
                        break;
                    case "Yellow":
                        rend.color = Color.yellow;
                        break;
                    default:
                        rend.color = Color.black;
                        break;
                }
                break;
            //case "Red":
            //    switch (TempColour)
            //    {
            //        case "Blue":
            //            rend.color = Color.LerpUnclamped(Color.red, Color.blue, 0.5f);
            //            break;
            //        case "Red":
            //            rend.color = Color.
            //            break;
            //        case "Yellow":
            //            rend.color = Color.LerpUnclamped(Color.red, Color.yellow, 0.5f);
            //            break;
            //        default:
            //            rend.color = Color.LerpUnclamped(Color.red, Color.blue, 0.5f);
            //            break;
            //    }
            //    break;

            default:
                Debug.Log("Twouble");
                break;
        }
    }
}
