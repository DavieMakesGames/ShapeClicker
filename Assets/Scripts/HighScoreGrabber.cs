using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScoreGrabber : MonoBehaviour
{
    public string Prepend ="";
    // Start is called before the first frame update
    void Start()
    {
        int hs = PlayerPrefs.GetInt("HighScore");
        if(hs > 0) GetComponent<TextMeshProUGUI>().text = Prepend + hs;
    }

}
