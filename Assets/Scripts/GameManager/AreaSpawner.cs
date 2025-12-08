using UnityEngine;
using System.Collections.Generic;

public class AreaSpawner : MonoBehaviour
{
    //this spawns enemies or objects in an area set in the inspector
    //not fully finished yet but could be used for the creep spawns
    //plan to make the baseCooldown act as a base number to adjust the 
    //other enemy/object type individual spawn cooldowns


    //==PUBLIC==//
    [Header("**This script can be used with enemies or other objects\n" +
        "The first(0) object in the List will spawn the most\n" +
        "Then add the rest in order of their spawn importance**")]
    [Header("--Spawnable Objects--")]
    public List<GameObject> spawnableObjList;

    [Header("--Area Spawner Object--")]
    public GameObject areaSpawner;

    [Header("--Spawner Data--")]
    public float spawnDelay;
    public int baseEnemyCnt; 
    [Header("--Spawn at once or over time--")]
    public bool isAllAtOnce;

    [Header("--Cooldown Counter--\n" +
        "Used to adjust the first objects spawn cooldown\n" +
        "All objects after the first will be\n" +
        "based on a multple of the base Cooldown")]
    public int baseCooldownRate; //this still needs work

    [Header("Range can be from 2 to 10 squares from edge to edge")]
    [Range(2, 10)]
    public int areaSize;


    //==PRIVATE==//
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float halfSize;
    private float time;
    private int tempCnt;


    void Start()
    {
        tempCnt = baseEnemyCnt;
        calculateAreaEdges();
        if (isAllAtOnce)
        {
            spawnSetAmount(baseEnemyCnt, (baseEnemyCnt / 2));
        }
    }

    void Update()
    {
        if (!isAllAtOnce)
        {
            time += Time.deltaTime;
            if (time >= spawnDelay)
            {
                //only spawns the first enemy for now
                spawnOverTime();
                time = 0;
            }
        }
    }
    private void calculateAreaEdges()
    {
        halfSize = areaSize / 2;                //gets the halfsize by dividing the areaSize by 2
        minX = transform.position.x - halfSize; //the gets the x and y values for the edges of the area
        maxX = transform.position.x + halfSize; //by adding/subtracting the halfsize from the 
        minY = transform.position.y - halfSize; //Area Spawner Objects x,y position
        maxY = transform.position.y + halfSize;
        //Debug.Log("minX: " + minX + " - maxX: " + maxX + " - minY: " + minY + " - maxY: " + maxY);
    }

    private void spawnOverTime()
    {
        if (tempCnt > 0)
        {
            spawnSingleObject(spawnableObjList[0]);
            tempCnt--;
        }
    }

    private void spawnSingleObject(GameObject go)
    {
        Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject tempMelee = Instantiate(go);
        tempMelee.transform.position = spawnPos;
    }

    private void spawnSetAmount(int cntOne, int cntTwo)
    {
        for (int i = 0; i < cntOne; i++)
        {
            spawnSingleObject(spawnableObjList[0]);
        }
        for(int i = 0; i < cntTwo; i++)
        {
            spawnSingleObject(spawnableObjList[1]);
        }
    }
}
