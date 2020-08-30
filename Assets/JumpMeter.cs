using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMeter : MonoBehaviour
{
    private MovementController _movementController => GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
    private Vector3 _colorFill = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (_colorFill.x != 0f)
             _colorFill.x = _movementController.JumpTimeCounter / _movementController.MaxJumpTime;
         else
             _colorFill.x = 1f;

         transform.localScale = _colorFill;
    }
}
