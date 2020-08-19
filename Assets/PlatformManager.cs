using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private void Awake()
    {
        PlatformPool.Instance.AddObjects(30);
    }
    public void SpawnPlatform(TypeOfPlatform platformType, Vector2 pos)
    {
        Platform platform = PlatformPool.Instance.Get();
        platform.SetPlatformType(platformType);
        platform.SetPlatformPosition(pos);
        platform.gameObject.SetActive(true);
    }
    private void Start()
    {
        
    }
}
