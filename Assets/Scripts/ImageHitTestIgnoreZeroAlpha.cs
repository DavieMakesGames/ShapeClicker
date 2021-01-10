using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ImageHitTestIgnoreZeroAlpha : MonoBehaviour
{
    public Image Button;

    // Use this for initialization
    void Start()
    {
        Button.alphaHitTestMinimumThreshold = 0.1f;
    }
}