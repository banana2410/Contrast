using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableCounter : MonoBehaviour
{
    private int _coinCount;

    public void AddCoins()
    {
        _coinCount++;
    }

}
