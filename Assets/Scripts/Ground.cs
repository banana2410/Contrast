using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : LevelPart
{

    void Start()
    {
        LevelSpawner.Instance.GetCurrentActiveLevelParts().Add(this);
    }
    public override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if (transform.position.x < -8.4f)
        {
            LevelSpawner.Instance.CanContinueSpawning = true;
        }
        if (transform.position.x < -32.5f)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector2.left * Time.deltaTime * 7f);
    }

}
