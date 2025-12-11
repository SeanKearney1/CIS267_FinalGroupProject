using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    //==PUBLIC==//
    [Header("--Spawner Objects--")]
    public GameObject negativeSideSpawner;
    public GameObject positiveSideSpawner;
    public GameObject enemyHolder;
    public bool isVerticalSpawner;

    [Header("Spawner Width: 1 should = 1 square")]
    [Range(1, 10)]
    public int maxSpawnerWidth;

    [Header("--Gatehouse and Path Waypoints Points--")]
    public GameObject cityGates;
    public List<GameObject> waypointList;

    //==PRIVATE==//
    private List<GameObject> tier1EnemyList = new List<GameObject>();
    private List<GameObject> tier2EnemyList = new List<GameObject>();
    private List<GameObject> tier3EnemyList = new List<GameObject>();
    private List<GameObject> tier4EnemyList = new List<GameObject>();
    private float time;
    private bool isSpawningWave;
    private float spawnDelay;

    void Start()
    {
        setSpawnerWidth();
        isSpawningWave = false;
    }
    void Update()
    {
        if (isSpawningWave)
        {
            time += Time.deltaTime;
            if (time >= spawnDelay)
            {
                spawnTier1Enemies();
                spawnTier2Enemies();
                spawnTier3Enemies();
                spawnTier4Enemies();
                time = 0;
            }
        }
        if (enemyHolder.transform.childCount <= 0 && tier1EnemyList.Count <= 0 && tier2EnemyList.Count <= 0 && tier3EnemyList.Count <= 0 && tier4EnemyList.Count <= 0)
        {
            isSpawningWave = false;
            WaveManager.wmInstance.setIsSpawningWave(false);
        }
    }

    public void setWaveData(float delay, List<GameObject> t1List, List<GameObject> t2List, List<GameObject> t3List, List<GameObject> t4List, bool isS)
    {
        spawnDelay = delay;
        tier1EnemyList = t1List;
        tier2EnemyList = t2List;
        tier3EnemyList = t3List;
        tier4EnemyList = t4List;
        isSpawningWave = isS;
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
    private void spawnTier1Enemies() // pass the enemy instead
    {
        if (tier1EnemyList.Count > 0)
        {
            Vector2 spawnPos = getSpawnerType();
            GameObject tempMelee = Instantiate(tier1EnemyList[0], enemyHolder.transform, true);
            tier1EnemyList.RemoveAt(0);
            tempMelee.GetComponent<EnemyController>().setDefaultTarget(cityGates);
            tempMelee.GetComponent<EnemyController>().setPathWaypoints(waypointList);
            tempMelee.transform.position = spawnPos;
        }
    }
    private void spawnTier2Enemies()
    {
        if (tier2EnemyList.Count > 0)
        {
            Vector2 spawnPos = getSpawnerType();
            GameObject tempMelee = Instantiate(tier2EnemyList[0], enemyHolder.transform, true);
            tier2EnemyList.RemoveAt(0);
            tempMelee.GetComponent<EnemyController>().setDefaultTarget(cityGates);
            tempMelee.GetComponent<EnemyController>().setPathWaypoints(waypointList);
            tempMelee.transform.position = spawnPos;
        }
    }
    private void spawnTier3Enemies()
    {
        if (tier3EnemyList.Count > 0)
        {
            Vector2 spawnPos = getSpawnerType();
            GameObject tempMelee = Instantiate(tier3EnemyList[0], enemyHolder.transform, true);
            tier3EnemyList.RemoveAt(0);
            tempMelee.GetComponent<EnemyController>().setDefaultTarget(cityGates);
            tempMelee.GetComponent<EnemyController>().setPathWaypoints(waypointList);
            tempMelee.transform.position = spawnPos;
        }
    }
    private void spawnTier4Enemies()
    {
        if (tier4EnemyList.Count > 0)
        {
            Vector2 spawnPos = getSpawnerType();
            GameObject tempMelee = Instantiate(tier4EnemyList[0], enemyHolder.transform, true);
            tier4EnemyList.RemoveAt(0);
            tempMelee.GetComponent<EnemyController>().setDefaultTarget(cityGates);
            tempMelee.GetComponent<EnemyController>().setPathWaypoints(waypointList);
            tempMelee.transform.position = spawnPos;
        }
    }
}
