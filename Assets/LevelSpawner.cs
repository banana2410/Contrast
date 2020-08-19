using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject levelPart;
    [SerializeField] private LevelPart[] allLevelParts = new LevelPart[3];
    private float _currentLevelSpeed = 2f;//Current level speed, equal to difficulty
    private List<LevelPart> _currentActiveLevelParts = new List<LevelPart>();



    #region Singleton

    public static LevelSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion

    private void Start()
    {
        createLevelPart(0, Vector3.zero);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLevelPart(Random.Range(0, 1));
        }
    }

    public List<LevelPart> GetCurrentActiveLevelParts()
    {
        return _currentActiveLevelParts;
    }
    /// <summary>
    /// Creates level part, places is to certain spot and adds it to the list of current active level parts
    /// </summary>
    /// <param name="levelPartNumber"></param>
    /// <param name="pos"></param>
    private void createLevelPart(int levelPartNumber, Vector2 pos)
    {
        LevelPart levelPart = Instantiate(allLevelParts[levelPartNumber].gameObject, position: pos, Quaternion.identity).GetComponent<LevelPart>();
        levelPart.AddToActiveLevelParts(_currentActiveLevelParts);
        levelPart.SetSpeedOfMoving(_currentLevelSpeed);

    }

    /// <summary>
    /// Spawns level part and place it at the end of the last active level part
    /// </summary>
    /// <param name="a"></param>
    public void SpawnLevelPart(int a)
    {
        int i = Random.Range(0, 4);//when working with int type, random.range upper limit is exclusive
        createLevelPart(a, _currentActiveLevelParts[_currentActiveLevelParts.Count - 1].GetLevelPartEnd().gameObject.transform.position);
    }

}
