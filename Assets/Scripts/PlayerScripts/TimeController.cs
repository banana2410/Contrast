using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
   public void SlowTime()
    {
        Time.timeScale = 0.7f;
    }
    public void SpeedTime()
    {
        Time.timeScale = 1.3f;
    }
}
