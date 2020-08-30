using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    private LevelPartEnd _levelPartEnd;
    private float _speedOfMoving;
    private List<Platform> _allPlatforms = new List<Platform>();



    private  void Start()
    {

        initPlatforms();
    }
    public virtual void Awake()
    {
        _levelPartEnd = gameObject.GetComponentInChildren<LevelPartEnd>();
    }

    private void Update()
    {
        movePlatform();
        if (_levelPartEnd.transform.position.x <= -10f)
        {
            RemoveFromActiveLevelParts(LevelSpawner.Instance.GetCurrentActiveLevelParts());
            //Return to pool
            Destroy(this.gameObject);
        }
    }
    public LevelPartEnd GetLevelPartEnd()
    {
        return _levelPartEnd;
    }

    private void initPlatforms()//Add all platforms in this level part to list and sets random platform type for each 
    {
        _allPlatforms.AddRange(gameObject.GetComponentsInChildren<Platform>());

        foreach (Platform plat in _allPlatforms)
        {
            plat.SetPlatformType(Random.Range(0, 2));
        }

    }
    public void RemoveFromActiveLevelParts(List<LevelPart> levelPartList)
    {
        levelPartList.Remove(this);
    }
    public void AddToActiveLevelParts(List<LevelPart> levelPartList)
    {
        levelPartList.Add(this);
    }
    private void movePlatform()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speedOfMoving, Space.Self);
    }
    public void SetSpeedOfMoving(float speed)
    {
        _speedOfMoving = speed;
    }
}
