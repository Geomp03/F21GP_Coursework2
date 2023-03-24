using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Components used
    private Rigidbody2D    playerRB;
    private SpriteRenderer playerRend;
    // private BoxCollider2D  boxcol;
    //public GameObject  bulletPrefab;
    //public Transform ShootingAim;
    //public Transform ShootingStaff;

    [SerializeField] float speed;
    private float DirX, DirY;
    private float angle;
    private string tempColour = "Default", baseColour = "Default", Potion;
    private Color finalColour;
    private bool holdingFlask;

    private PlayerAim playerAim;

    // Costum Colours Used
    public Color CostumBlue = new Color(0.1921569f, 0.3647059f, 0.9019608f);
    public Color CostumRed = new Color(0.9372550f, 0.2470588f, 0.2509804f);
    public Color CostumYellow = new Color(0.9607844f, 0.8705883f, 0.1960784f);
    public Color CostumOrange = new Color(0.9058824f, 0.5725490f, 0.1568628f);
    public Color CostumGreen = new Color(0.2156863f, 0.9490197f, 0.0000000f);
    public Color CostumPurple = new Color(0.6823530f, 0.0784314f, 0.9686275f);

    

    // Start is called before the first frame update
    private void Start()
    {
        // Initialise all components needed...
        playerRB   = GetComponent<Rigidbody2D>();
        playerRend = GetComponent<SpriteRenderer>();
        // boxcol = GetComponent<BoxCollider2D>();

        holdingFlask = false;
    }


    // Update is called once per frame
    private void Update()
    {
        // Movement
        DirX = Input.GetAxis("Horizontal");
        DirY = Input.GetAxis("Vertical");
        
        playerRB.velocity = new Vector2(DirX * speed, DirY * speed);


        //// Player sprite rotation based on movement
        //if (DirX != 0 || DirY !=0)
        //{
        //    angle = Mathf.Atan2(DirY, DirX) * Mathf.Rad2Deg - 90f;
        //}
        //playerRB.rotation = angle;


        // Handle colour changes
        ColourEval();
        playerRend.color = finalColour;


        


        // Potion mechanic
        if (holdingFlask == true && Input.GetButtonDown("UseItem") && Potion == "Default")
        {
            Potion = tempColour;
            Debug.Log("Potion colour is: " + Potion);
        }
        else if (holdingFlask == true && Input.GetButtonDown("UseItem") && Potion!="Default")
        {
            baseColour = Potion;
            Potion = "Default";
            Debug.Log("Potion colour is: " + Potion);
        }

    }



    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug info
        Debug.Log("Player collied with " + col.gameObject.name + " @ " + Time.time);

        // On entering a colour puddle set tempColour to the appropriate colour.
        if (col.gameObject.name.Contains("BluePuddle"))
            tempColour = "Blue";
        else if (col.gameObject.name.Contains("RedPuddle"))
            tempColour = "Red";
        else if (col.gameObject.name.Contains("YellowPuddle"))
            tempColour = "Yellow";

        // Pickup empty flask
        else if (col.gameObject.name.Contains("Potion"))
        {
            holdingFlask = true;
            Debug.Log("Holding empty flask");
        }

        else if (col.gameObject.name.Contains("Enemy"))
        {
            // Lose health???
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // After leaving a colour puddle return tempColour to "default".
        if (col.gameObject.name.Contains("BluePuddle") || col.gameObject.name.Contains("RedPuddle") || col.gameObject.name.Contains("YellowPuddle"))
            tempColour = "Default";
    }



    // Shooting Colourful bullets
    //private void Shoot()
    //{
    //    // Instantiate bullet prefab
    //    GameObject bullet = Instantiate(bulletPrefab, ShootingStaff.position, ShootingAim.rotation);

    //    // Add force to the bullet using its rigib body. Force always points forward from where the character is looking.
    //    Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
    //    bulletRB.AddForce(ShootingAim.up * shootForce, ForceMode2D.Impulse);

    //    // Set the starting color of the bullet prefab to the players current colour
    //    SpriteRenderer bulletRend = bullet.GetComponent<SpriteRenderer>();
    //    bulletRend.color = playerRend.color;
    //}


    // Evaluate Colour changes and combinations
    public void ColourEval()
    {
        switch (baseColour)
        {
            case "Default":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumBlue;
                        break;
                    case "Red":
                        finalColour = CostumRed;
                        break;
                    case "Yellow":
                        finalColour = CostumYellow;
                        break;
                    default:
                        finalColour = Color.black;
                        break;
                }
                break;

            case "Blue":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumBlue;
                        break;
                    case "Red":
                        finalColour = CostumPurple;
                        break;
                    case "Yellow":
                        finalColour = CostumGreen;
                        break;
                    default:
                        finalColour = CostumBlue;
                        break;
                }
                break;

            case "Yellow":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumGreen;
                        break;
                    case "Red":
                        finalColour = CostumOrange;
                        break;
                    case "Yellow":
                        finalColour = CostumYellow;
                        break;
                    default:
                        finalColour = CostumYellow;
                        break;
                }
                break;
            case "Red":
                switch (tempColour)
                {
                    case "Blue":
                        finalColour = CostumPurple;
                        break;
                    case "Red":
                        finalColour = CostumRed;
                        break;
                    case "Yellow":
                        finalColour = CostumOrange;
                        break;
                    default:
                        finalColour = CostumRed;
                        break;
                }
                break;

            default:
                Debug.Log("Twouble");
                break;
        }
    }
}
