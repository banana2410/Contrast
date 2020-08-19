using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityDir
{
    Down, Up
}
public class GravityController : MonoBehaviour
{

    private Rigidbody2D _rb;
    public GravityDir _gravityDir;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            changeGravity(_gravityDir);
        }  
    }
 
    private void changeGravity(GravityDir gravity)
    {
        switch (gravity)
        {
            case GravityDir.Down:
                _rb.gravityScale = -3;
                _gravityDir = GravityDir.Up;
                break;
            case GravityDir.Up:
                _rb.gravityScale = 3;
                _gravityDir = GravityDir.Down;
                break;
            default:
                break;
        }
    }
}
