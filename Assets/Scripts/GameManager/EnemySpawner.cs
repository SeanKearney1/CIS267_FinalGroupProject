using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    //==PUBLIC==//
    [Header("--Spawners--")]
    public GameObject negativeSideSpawner;
    public GameObject positiveSideSpawner;
    public bool isVerticalSpawner;

    [Header("Spawner Width: 1 should = 1 square")]
    [Range(1, 10)]
    public int maxSpawnerWidth;

    //could set other spawn delays here too for differnt enemy types
    //[Header("--Spawn Data--")]
    public float spawnDelay;
    public int tier1BaseCount;
    public int tier2BaseCount;
    public int tier3BaseCount;
    public float tier1EnemyMultiplier;
    public float tier2EnemyMultiplier;
    public float tier3EnemyMultiplier;

    [Header("--Eneimes To Spawn In--")]
    public GameObject tier1Enemy;
    public GameObject tier2Enemy;
    public GameObject tier3Enemy;


    [Header("--Gatehouse and Path Waypoints Points--")]
    public GameObject cityGates;
    public List<GameObject> waypointList;

    //==PRIVATE==//
    private int currentLevel; //get this from the game manager
    private float time;
    //These keep track of how many enemy of each type will spawn this round
    //adding to it or multiplying it by X amount
    private float currentTier1Cnt;
    private float currentTier2Cnt;
    private float currentTier3Cnt;
    private bool isSpawningWave;
    private int tempT1Cnt;
    private int tempT2Cnt;
    private int tempT3Cnt;



    void Start()
    {
        setSpawnerWidth();
        resetSpawnData();
        updateEnemyCounts();
    }

    void Update()
    {
        if (isSpawningWave)
        {
            time += Time.deltaTime;
            if (time >= spawnDelay)
            {
                //spawnTier1Enemies();
                spawnNextLevel();
                time = 0;
            }
        }
    }
    private void resetSpawnData()
    {
        currentLevel = 1;
        isSpawningWave = false;
        tempT1Cnt = 0;
        tempT2Cnt = 0;
        tempT3Cnt = 0;
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
        else if(currentLevel >= 2)
        {
            //add multipliers
            currentTier1Cnt = Mathf.RoundToInt(currentTier1Cnt * tier1EnemyMultiplier);
            currentTier2Cnt = Mathf.RoundToInt(currentTier2Cnt * tier2EnemyMultiplier);
            currentTier3Cnt = Mathf.RoundToInt(currentTier3Cnt * tier3EnemyMultiplier);
        }
    }



    private void spawnNextLevel()
    {

        if (tempT1Cnt < currentTier1Cnt)
        {
            spawnTier1Enemies();
            //tempT1Cnt++;
        }
        else if(tempT1Cnt >= currentTier1Cnt)
        {
            resetSpawnData();
        }
        if (currentTier2Cnt > tempT2Cnt)
        {

            tempT2Cnt++;
        }
        if (currentTier3Cnt > tempT3Cnt)
        {
            tempT3Cnt++;
        }
    }

    private void spawnTier1Enemies() // pass the enemy instead
    {
        Vector2 spawnPos = getSpawnerType();
        GameObject tempMelee = Instantiate(tier1Enemy);
        tempMelee.GetComponent<EnemyController>().setDefaultTarget(cityGates);
        tempMelee.GetComponent<EnemyController>().setPathWaypoints(waypointList);
        tempMelee.transform.position = spawnPos;
        tempT1Cnt++;
    }

    private Vector2 getSpawnerType()
    {
        setSpawnerWidth();
        if (isVerticalSpawner)
        {
            float randomY = Random.Range(negativeSideSpawner.transform.position.y, positiveSideSpawner.transform.position.y);
            return new Vector2(negativeSideSpawner.transform.position.x, randomY);
        }
        else
        {
            float randomX = Random.Range(negativeSideSpawner.transform.position.x, positiveSideSpawner.transform.position.x);
            return new Vector2(randomX, negativeSideSpawner.transform.position.y);
        }
    }
    private void setSpawnerWidth()
    {
        if (isVerticalSpawner)
        {
            gameObject.transform.localScale = new Vector3(0.2f, maxSpawnerWidth, 0);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(maxSpawnerWidth, 0.2f, 0);
        }
    }
    public void setSpawnDelay(int delay)
    {
        spawnDelay = delay;
    }

    public void nextLevel() // for testing for now
    {
        currentLevel++;
    }


    public void testNextLevel()
    {
        currentLevel++;
        isSpawningWave = true;
        updateEnemyCounts();
    }
}
