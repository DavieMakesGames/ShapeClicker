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
    public Animator Animator;
    public AudioSource AudioSource;
    public List<AudioClip> AudioClips;

    void Start()
    {
        //Add listener for when the value of the Dropdown changes, to take action
        Dropdown.onValueChanged.AddListener(delegate {
            ChangeShape(Dropdown.options[Dropdown.value].image);
        });

    }

    public void ShapeClick()
    {
        float clickDelta = Time.time - _lastClickTime;
        bool doubleClick = clickDelta <= DOUBLE_CLICK_TIME;

        if (doubleClick) 
        {
            ChangeColor();
            Animator.SetTrigger("DoubleClick");
            AudioSource.volume = 1;
            AudioSource.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Count)]);
        }
        else
        {
            AudioSource.volume = .35f;
            AudioSource.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Count)]);
        }

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
