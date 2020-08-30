using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent DeathEvent;
    private int _healthPoints = 1;
    private ColorController _colorController => gameObject.GetComponent<ColorController>();

    public void AddLife()
    {
        _healthPoints++;
    }
    public void RemoveLife()
    {
        if (isAlive())
        {
            _healthPoints--;
            if (!isAlive())
                KillPlayer();
        }
    }
    public void KillPlayer()
    {
        DeathEvent.Invoke();
    }
    private bool isAlive()
    {
        return _healthPoints > 0;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        doCollisionCheck(collision);
    }
    private void doCollisionCheck(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Platform platform = collision.gameObject.GetComponent<Platform>();

            //if (platform.PlatformType != _colorController.GetColor())

        }
    }
}
