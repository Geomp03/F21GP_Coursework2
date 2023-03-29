using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageDisp : MonoBehaviour
{
    public TMP_Text canvasText;

    // Pass message to canvas TMP
    public IEnumerator UIMessages(string message, float delay)
    {
        canvasText.text = message;
        canvasText.enabled = true;
        yield return new WaitForSeconds(delay);
        canvasText.enabled = false;
    }
}
