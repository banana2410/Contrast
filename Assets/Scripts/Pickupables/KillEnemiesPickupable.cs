using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemiesPickupable : Pickupable
{
    public override void OnPickup(Collider2D col)
    {
        List<EnemyHealth> allEnemies = new List<EnemyHealth>();
        allEnemies.AddRange(FindObjectsOfType<EnemyHealth>());
        foreach (EnemyHealth enemy in allEnemies)
        {
            enemy.Kill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        OnPickup(collision);
    }
}

