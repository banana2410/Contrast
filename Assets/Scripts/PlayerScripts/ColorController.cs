using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public enum Color
{
    Dark,
    Bright
}

public class ColorController : MonoBehaviour
{
    public GameObject BrightEffect;
    public GameObject DarkEffect;

    private Color _color = Color.Bright;
    private SpriteRenderer _spriteRenderer => gameObject.GetComponent<SpriteRenderer>();
    private Vector4 _whiteColor = new Vector4(255f, 255f, 255f, 255f);
    private Vector4 _blackColor = new Vector4(0f, 0f, 0f, 255f);


    private void Awake()
    {
        
    }
    private void Start()
    {
        changeColorSprite(_whiteColor);
    }

    public Color GetColor()
    {
        return _color;
    }
    public void ChangeColor()
    {
        switch (_color)
        {
            case Color.Dark:
                Debug.Log("Dark");
                Instantiate(BrightEffect, position: this.gameObject.transform.position, Quaternion.identity);
                changeColorSprite(_whiteColor);
                _color = Color.Bright;
                break;
            case Color.Bright:
                Debug.Log("brrr");
                Instantiate(DarkEffect, position: this.gameObject.transform.position, Quaternion.identity);
                changeColorSprite(_blackColor);
                _color = Color.Dark;
                break;
            default:
                break;
        }
    }
    /*public void ChangeColor()
    {
        if (_color == Color.Bright)
            _color = Color.Dark;
        if (_color == Color.Dark)
            _color = Color.Bright;
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeColor();
        }
    }
    private void changeColorSprite(Vector4 color)
    {
        Debug.Log(color);
        _spriteRenderer.color = color;
    }
}
