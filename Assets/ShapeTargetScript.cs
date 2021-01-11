using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
public class ShapeTargetScript : MonoBehaviour
{

    private RectTransform _rect;
    private Image _targetShapeImage;
    private bool _validMultiplier = false;

    // Start is called before the first frame update
    public float Speed = 100f;
    public bool OnScreen = false;
    public bool ShapeMatches = false;

    public Image CurrentlySelectedImage;
    public List<Sprite> Shapes;

    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _targetShapeImage = GetComponent<Image>();
        ChangeImage();
    }

    private void ChangeImage()
    {
        _targetShapeImage.sprite = Shapes[Random.Range(0, Shapes.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        float x = _rect.anchoredPosition.x;
        float y = _rect.anchoredPosition.y;

        if (x >= 1890) 
        {
            _rect.anchoredPosition = new Vector2(-1080, y);
            ChangeImage();
        } 
        else _rect.anchoredPosition = new Vector2(x + (Speed * Time.deltaTime), y);

        OnScreen = (x > -270 && x < Screen.width);
        ShapeMatches = (CurrentlySelectedImage.sprite.name == _targetShapeImage.sprite.name);

        if (OnScreen && ShapeMatches) 
        {
            if (!_validMultiplier)
            {
                _validMultiplier = true;
                _targetShapeImage.color = Color.green;
                GameManager.Instance.IncreaseMultiplier();
            }
        } 
        else
        {
            if (_validMultiplier) 
            {
                _validMultiplier = false;
                _targetShapeImage.color = Color.red;
                GameManager.Instance.DecreaseMultiplier();
            } 
        } 
    }

    public bool ValidMultiplier
    {
        get => _validMultiplier;
    }

}
