using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("--Enemy Spawners--")]
    public GameObject[] listOfSpawners;

    [Header("--Enemy Spawn Types--")]
    public GameObject tier1Enemy;
    public GameObject tier2Enemy;
    public GameObject tier3Enemy;

    [Header("--Spawn Data--")]
    public float spawnDelay;
    public int tier1BaseCount;
    public int tier2BaseCount;
    public int tier3BaseCount;
    public float tier1EnemyMultiplier;
    public float tier2EnemyMultiplier;
    public float tier3EnemyMultiplier;

    private int currentLevel; //get this from the game manager
    //private float time;
    private float currentTier1Cnt;
    private float currentTier2Cnt;
    private float currentTier3Cnt;
    private bool isSpawningWave;
    private int tempT1Cnt;
    private int tempT2Cnt;
    private int tempT3Cnt;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void nextLevel() // for testing for now
    {
        currentLevel++;
    }
    private void resetSpawnData()
    {
        currentLevel = 1;
        isSpawningWave = false;
        tempT1Cnt = 0;
        tempT2Cnt = 0;
        tempT3Cnt = 0;
    }

    public void testNextLevel()
    {
        currentLevel++;
        isSpawningWave = true;
        updateEnemyCounts();
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
            currentTier2Cnt = Mathf.RoundToInt(currentTier2Cnt * tier2EnemyMultiplier);
            currentTier3Cnt = Mathf.RoundToInt(currentTier3Cnt * tier3EnemyMultiplier);
        }
    }
}
