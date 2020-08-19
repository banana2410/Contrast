using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimePickupable : Pickupable
{
    public override void OnPickup(Collider2D col)
    {
        col.GetComponent<TimeController>().SlowTime();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        OnPickup(collision);
    }
}
