﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void Kill()
    {
        Destroy(this.gameObject);
    }
    private void OnMouseDown()
    {
        Kill();
    }
}
