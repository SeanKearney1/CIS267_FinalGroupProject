using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [Header("--Spawners--")]
    public GameObject negativeSideSpawner;
    public GameObject positiveSideSpawner;
    public bool isVerticalSpawner;

    [Header("Spawner Width: 1 should = 1 square")]

    [Range(1, 10)]
    public int maxSpawnerWidth;

    [Header("--Eneimes To Spawn In--")]
    public GameObject meleeEnemy;
    public GameObject rangedEnemy;
    public GameObject bossEnemy;


    [Header("--Gatehouse and Path Waypoints Points--")]
    public GameObject cityGates;
    public List<GameObject> waypointList;


    //could set other spawn delays here too for differnt enemy types
    [Header("--Spawn Data--")]
    public float spawnDelay;


    private int currentLevel; //get this from the game manager
    private float time;
    //These keep track of how many enemy of each type will spawn this round
    //adding to it or multiplying it by X amount
    private int currentMeleeCnt; 
    private int currentRangedCnt;
    private int currentBossCnt;



    void Start()
    {
        setSpawnerWidth();
        currentLevel = 1;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= spawnDelay)
        {
            spawnMeleeEnemy();
            time = 0;
        }
    }

    public void nextLevel() // for testing for now
    {
        currentLevel++;
    }

    private void spawnNextLevel()
    {

    }

    private void spawnMeleeEnemy()
    {
        Vector2 spawnPos = getSpawnerType();
        GameObject tempMelee = Instantiate(meleeEnemy);
        tempMelee.GetComponent<EnemyController>().setDefaultTarget(cityGates);
        tempMelee.GetComponent<EnemyController>().setPathWaypoints(waypointList);
        tempMelee.transform.position = spawnPos;
    }
    
    private Vector2 getSpawnerType()
    {
        setSpawnerWidth();
        if(isVerticalSpawner)
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
        if(isVerticalSpawner)
        {
            gameObject.transform.localScale = new Vector3(0.2f, maxSpawnerWidth, 0);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(maxSpawnerWidth, 0.2f, 0);
        }
    }
}
