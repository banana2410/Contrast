using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _timer;
    private bool shouldSlowTime;

    private void Update()
    {
        if (shouldSlowTime)
            slowTime();

    }
    private void slowTime()//popravit to i triggerslowtime
    {
        _timer += Time.deltaTime;
        Time.timeScale = 0.7f;
        if (_timer >= 2f)
        {
            Time.timeScale = 1f;
            shouldSlowTime = false;
        }

    }
    public void TriggerSlowTime()
    {
        shouldSlowTime = true;
    }
    //  public void NormalTime
    public void SpeedTime()
    {
        Time.timeScale = 1.3f;
    }
}
