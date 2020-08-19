using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Color
{
    Dark,
    Bright
}

public class ColorController : MonoBehaviour
{
    public Color _color;
    private void changeColor(Color color)
    {
        switch (color)
        {
            case Color.Dark:
                _color = Color.Bright;
                break;
            case Color.Bright:
                _color = Color.Dark;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            changeColor(_color);
        }
    }
}
