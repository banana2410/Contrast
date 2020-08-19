using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _healthPoints = 1;

    public void AddLife()
    {
        _healthPoints++;
    }
    public void RemoveLife()
    {
        if (_healthPoints > 0)
            _healthPoints--;
    }
    public void KillPlayer()
    {
        _healthPoints = 0;
    }

}
