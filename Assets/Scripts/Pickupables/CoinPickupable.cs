using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupable : Pickupable
{
    public override void OnPickup(Collider2D col)
    {
        col.GetComponent<PickupableCounter>().AddCoins();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        OnPickup(other);
    }
}
