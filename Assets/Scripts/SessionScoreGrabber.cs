using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SessionScoreGrabber : MonoBehaviour
{
    public ScoreKeeper ScoreKeeper;
    public string Prepend ="";
    // Start is called before the first frame update
    void Start()
    {
       if(ScoreKeeper.Score > 0) GetComponent<TextMeshProUGUI>().text = Prepend + ScoreKeeper.Score;
    }

}
