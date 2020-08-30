using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum LevelDifficulty
{
    Easy,
    Medium,
    Hard
}
public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private LevelPart[] _easyLevelParts = new LevelPart[4];
    [SerializeField] private LevelPart[] _mediumLevelParts = new LevelPart[4];
    [SerializeField] private LevelPart[] _hardLevelParts = new LevelPart[4];

    private List<LevelPart> _currentActiveLevelParts = new List<LevelPart>();

    private int _currentSelectedLevelPart;
    private float _currentLevelSpeed = 7f;//Current level speed, equal to difficulty
    private float timer;

    private LevelDifficulty _levelDifficulty = LevelDifficulty.Easy;
    public bool CanContinueSpawning = false; // Created so level lays out nicely after beggining ground tiles



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

        // createLevelPart(Random.Range(0, 3), Vector2.zero); //Load initial level part in the game, made like this so there is something in active level part list
        //  SpawnLevelPart(Random.Range(0, 3));
    }
    private void Update()
    {

        timer += Time.deltaTime;
        if (CanContinueSpawning && timer >= 1f)
        {
           determineLevelDifficulty();
            timer = 0f;
        }
    }


    private void determineLevelDifficulty()
    {
        if (Time.time >= 5f)
            _levelDifficulty = LevelDifficulty.Medium;
        if (Time.time >= 15f)
            _levelDifficulty = LevelDifficulty.Hard;
        switch (_levelDifficulty)
        {
            case LevelDifficulty.Easy:
                _currentLevelSpeed = 6f;
                SpawnLevelPart(Random.Range(0, 4), _easyLevelParts);
                break;
            case LevelDifficulty.Medium:
                _currentLevelSpeed = 8f;
                SpawnLevelPart(Random.Range(0, 4), _mediumLevelParts);
                break;
            case LevelDifficulty.Hard:
                _currentLevelSpeed = 11f;
                SpawnLevelPart(Random.Range(0, 4), _hardLevelParts);
                break;
            default:
                break;
        }
    }

    public List<LevelPart> GetCurrentActiveLevelParts()
    {
        return _currentActiveLevelParts;
    }
    /// <summary>
    /// Creates level part of certain difficulty, places is to certain spot and adds it to the list of current active level parts
    /// </summary>
    /// <param name="levelPartArray"></param>
    /// <param name="levelPartNumber"></param>
    /// <param name="pos"></param>
    private void createLevelPart(LevelPart[] levelPartArray, int levelPartNumber, Vector2 pos)
    {
        LevelPart levelPart = Instantiate(levelPartArray[levelPartNumber].gameObject, position: pos, Quaternion.identity).GetComponent<LevelPart>();
        levelPart.AddToActiveLevelParts(_currentActiveLevelParts);
        levelPart.SetSpeedOfMoving(_currentLevelSpeed);
    }

    /// <summary>
    /// Spawns level part and place it at the end of the last active level part
    /// </summary>
    /// <param name="a"></param>
    public void SpawnLevelPart(int i, LevelPart[] levelPartArray)
    {
        // int i = Random.Range(0, 3);//when working with int type, random.range upper limit is exclusive
        Vector3 pos = _currentActiveLevelParts[_currentActiveLevelParts.Count - 1].GetLevelPartEnd().gameObject.transform.position;
        pos.x = 16.7f;
        pos.y = 0f;
        createLevelPart(levelPartArray, i, pos);
    }

}
