using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlKeyUI : MonoBehaviour
{
    public Image image;
    public void InstKeyUI(bool instKeyUI)
    {
        // gameObject.SetActive(instPotionUI);
        image.enabled = instKeyUI;
    }
}
