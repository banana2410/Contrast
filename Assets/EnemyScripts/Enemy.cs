using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.RemoveLife();
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 5f);
    }
}
