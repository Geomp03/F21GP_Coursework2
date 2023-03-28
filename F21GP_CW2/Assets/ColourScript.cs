using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourScript : MonoBehaviour
{
    private PlayerColour playerColour;
    private Material material;

    private void Awake()
    {
        playerColour = FindObjectOfType<PlayerColour>();
        material = GetComponent<SpriteRenderer>().sharedMaterial;
    }

    void Start()
    {
        
    }


    void Update()
    {
        material.SetColor("_Color", playerColour.finalColour);
    }
}
