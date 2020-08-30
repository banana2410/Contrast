using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTimePickupable : Pickupable
{
    private float _timer;
    public override void OnPickup(Collider2D col)
    {
        col.GetComponent<TimeController>().TriggerSlowTime();
    }
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        OnPickup(collision);
    }
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 2f);
    }
}
