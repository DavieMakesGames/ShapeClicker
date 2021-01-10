using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShapeShifterScript : MonoBehaviour
{
    private float _lastClickTime;

    public const float DOUBLE_CLICK_TIME = .3f;
    public Image Image;
    public TMP_Dropdown Dropdown;

    void Start()
    {
        //Add listener for when the value of the Dropdown changes, to take action
        Dropdown.onValueChanged.AddListener(delegate {
            ChangeShape(Dropdown.options[Dropdown.value].image);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShapeClick()
    {
        float clickDelta = Time.time - _lastClickTime;
        if (clickDelta <= DOUBLE_CLICK_TIME) ChangeColor();
        _lastClickTime = Time.time;
    }

    public void ChangeColor()
    {
        Image.color = new Color(Random.value, Random.value, Random.value);
    }

    public void ChangeShape(Sprite img)
    {
        Image.sprite = img;
    }
}
