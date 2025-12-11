using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager wmInstance { get; private set; }

    [Header("--Enemy Spawners--")]
    public GameObject[] listOfSpawners;

    [Header("--Enemy Spawn Types--")]
    public GameObject tier1Enemy;
    public GameObject tier2Enemy;
    public GameObject tier3Enemy;
    public GameObject tier4Enemy;

    [Header("--Spawn Data--")]
    public float baseSpawnDelay;
    public int tier1BaseCount;
    public int tier2BaseCount;
    public int tier3BaseCount;
    public int tier4BaseCount;
    public float tier1EnemyMultiplier;
    public float tier2EnemyMultiplier;
    public float tier3EnemyMultiplier;
    public float tier4EnemyMultiplier;
    public int tier2StartWave;
    public int tier3StartWave;
    public int tier4StartWave;
    public int endOfLevelCap;

    private List<GameObject> tier1EnemyList = new List<GameObject>();
    private List<GameObject> tier2EnemyList = new List<GameObject>();
    private List<GameObject> tier3EnemyList = new List<GameObject>();
    private List<GameObject> tier4EnemyList = new List<GameObject>();
    private int currentLevel; 
    //private EnemySpawner tempSpawner;
    //private float time;
    private UI_WaveTimer waveTimer;
    private int currentTier1Cnt;
    private int currentTier2Cnt;
    private int currentTier3Cnt;
    private int currentTier4Cnt;
    private bool isSpawningWave;
    //private int tempT1Cnt;
    //private int tempT2Cnt;
    //private int tempT3Cnt;
    //private int tempT4Cnt;

    private void Awake()
    {
        if (wmInstance != null && wmInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        wmInstance = this;
    }

    void Start()
    {
        isSpawningWave = false;
        fullResetWaveData();
        //startWave();
        //currentLevel = 1;
        //spawnerOne = listOfSpawners[0].GetComponent<EnemySpawner>();
    }
    void Update()
    {
        Debug.Log("current lvl: " + currentLevel);
    }
    public void setWaveTimerScript(UI_WaveTimer wTimer)
    {
        waveTimer = wTimer;
    }
    private List<GameObject> setEnemySpawnList(GameObject enemy, int cnt)
    {
        List<GameObject> tempList = new List<GameObject>();
        for (int i = 0; i < cnt; i++)
        {
            tempList.Add(enemy);
        }
        return tempList;
    }
    private void setSpawnerData()
    {
        foreach (GameObject go in listOfSpawners)
        {
            EnemySpawner tempSpawner = go.GetComponent<EnemySpawner>();
            //tempSpawner.setEnemyTypes(tier1Enemy, tier2Enemy, tier3Enemy);
            tempSpawner.setWaveData(baseSpawnDelay, tier1EnemyList, tier2EnemyList, tier3EnemyList, tier4EnemyList, isSpawningWave);
        }
    }
    private void populateWaveEnemies()
    {
        tier1EnemyList = setEnemySpawnList(tier1Enemy, currentTier1Cnt);
        if (currentLevel > tier2StartWave)
        {
            tier2EnemyList = setEnemySpawnList(tier2Enemy, currentTier2Cnt);
        }
        if (currentLevel > tier3StartWave)
        {
            tier3EnemyList = setEnemySpawnList(tier3Enemy, currentTier3Cnt);
        }
        if(currentLevel > tier4StartWave)
        {
            tier4EnemyList = setEnemySpawnList(tier4Enemy, currentTier4Cnt);
        }
    }
    public void setNextWave() // could call this in the wave timer when timer expires
    {
        currentLevel++;
    }
    public void setIsSpawningWave(bool isS)
    {
        isSpawningWave = isS;
        if (currentLevel == 15) // levle complete
        {
            GameManagerLogic.Instance.setIsLevelOver(true);
        }
    }
    public bool getIsSpawningWave()
    {
        return isSpawningWave;
    }
    public void startWave()
    {
        setNextWave();
        UI_Hotbar.hbInstance.setWaveCount(currentLevel);
        isSpawningWave = true;
        updateEnemyCounts();
        populateWaveEnemies();
        setSpawnerData();
    }
    private void fullResetWaveData()
    {
        currentLevel = 0;
        isSpawningWave = false;
        currentTier1Cnt = tier1BaseCount;
        currentTier2Cnt = tier2BaseCount;
        currentTier3Cnt = tier3BaseCount;
    }
    private void updateEnemyCounts()
    {
        if (currentLevel == 1)
        {
            //no multipliers
            currentTier1Cnt = tier1BaseCount;
            currentTier2Cnt = tier2BaseCount;
            currentTier3Cnt = tier3BaseCount;
        }
        else if (currentLevel >= 2)
        {
            //add multipliers
            currentTier1Cnt = Mathf.RoundToInt(currentTier1Cnt * tier1EnemyMultiplier);
            if (currentLevel >= 5)
            {
                currentTier2Cnt = Mathf.RoundToInt(currentTier2Cnt * tier2EnemyMultiplier);

            }
            else if (currentLevel >= 10)
            {
                currentTier3Cnt = Mathf.RoundToInt(currentTier3Cnt * tier3EnemyMultiplier);
            }
        }
    }
    public void testing()
    {
        currentLevel = 14;
        GameManagerLogic.Instance.setIsGameWon(true);
    }
}
