using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private void Awake()
    {
        PlatformPool.Instance.AddObjects(30);
    }
    /// <summary>
    /// Spawn platform with wanted type(dark/bright) and place it on position
    /// </summary>
    /// <param name="platformType"></param>
    /// <param name="pos"></param>
    public void SpawnPlatform(Color platformType, Vector2 pos)
    {
        Platform platform = PlatformPool.Instance.Get();
        platform.SetPlatformType(platformType);
        platform.SetPlatformPosition(pos);
        platform.gameObject.SetActive(true);
    }
}
