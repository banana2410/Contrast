using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfPlatform
{
    Dark, Light
}
public class Platform : MonoBehaviour
{
    public TypeOfPlatform typeOfPlatform;
    private SpriteRenderer _spriteRenderer;
    private Vector4 _blackColor = new Vector4(255f, 255f, 255f, 255f);
    private Vector4 _whiteColor = new Vector4(0f, 0f, 0f, 255f);

    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void changePlatformColor()//Sets color to corresponding color
    {
        if (typeOfPlatform == TypeOfPlatform.Dark)
            _spriteRenderer.color = _blackColor;
        else
            _spriteRenderer.color = _whiteColor;
    }
    /// <summary>
    /// Sets platform type, bright or dark
    /// </summary>
    /// <param name="platformType"></param>
    public void SetPlatformType(TypeOfPlatform platformType)
    {
        typeOfPlatform = platformType;
    }
    public void SetPlatformType(int i)
    {
        typeOfPlatform = (TypeOfPlatform)i;
        changePlatformColor();
    }
    public void SetPlatformPosition(Vector2 pos)
    {
        transform.position = pos;
    }

}
