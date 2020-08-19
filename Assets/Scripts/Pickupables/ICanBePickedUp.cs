using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanBePickedUp
{
    void OnPickup(Collider2D col);
}
