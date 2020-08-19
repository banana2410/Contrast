using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
    public virtual void OnPickup(Collider2D collision)
    {

    }
}
