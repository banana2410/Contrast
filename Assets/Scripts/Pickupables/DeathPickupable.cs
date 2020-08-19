using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPickupable : Pickupable, ICanBePickedUp
{
    public void OnPickup(Collider2D col)
    {
        col.GetComponent<Health>().KillPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        OnPickup(collision);
    }
}
