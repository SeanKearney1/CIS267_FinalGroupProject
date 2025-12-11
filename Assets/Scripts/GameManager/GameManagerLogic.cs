using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/*
 
This script is the where the main logic for the
Game Manager GameObject is held.
 
 
 
*/
public class GameManagerLogic : MonoBehaviour
{
    //=====================================================
    // V  A  R  I  A  B  L  E  S
    //=====================================================

    // PUBLIC 
    public static GameManagerLogic Instance { get; private set; }
    public GameObject LevelUIPrefab;
    // PRIVATE
    private GameObject LevelUIPrefabGameObject;
    private GameObject PauseMenuGameObject;



    //==FOR WEAPON HANDLING AND PASSING DATA BETWEEN SCENES/LEVELS==// 

    //==PUBLIC==//
    [Header("--Default Weapon/Shield Objects--")]
    public WeaponObject defaultWeapon;
    public WeaponObject defaultShield;
    [Header("--Weapon Scriptable Object List--")]
    public List<WeaponObject> weaponScriptObjList;
    //[Header("--Repair Hammer / Extra Object(maybe health pot)--")]
    //public WeaponObject repairHammerObj;
    //public WeaponObject healthPotObj;

    //==PRIVATE==//
    //used to keep track of random order of play for new game
    private List<int> listOfRandomSceneOrder = new List<int> { 1, 2, 3 };
    private List<WeaponObject> playerWeaponInventory;
    private GameObject equippedWeapon;

    //used if we make the hammer a reward rather than already owned
    private bool hasRepairHammer;
    private int healthPotCount;
    private bool isGameWon;
    private bool isGameOver;
    private bool isGamePaused;
    private bool isLevelOver;


    //=====================================================
    //=====================================================
    //=====================================================
    //=====================================================================================
    // I  N  I  T  I  L  I  A  Z  I  N  G      F  U  N  C  T  I  O  N  S
    //=====================================================================================
    // Code taken from class, makes sure GameManager is the only one.

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        resetGameData();
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        Debug.Log(SceneManager.GetActiveScene());
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // When a new scene is loaded, if the scene if a level scene
    // (has the String "Level" in it) then it will run logic to 
    // startup any needed generic level logic.

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Contains("Level"))
        {
            Init_Level();
        }
    }

    //=====================================================================================
    //=====================================================================================
    //=====================================================================================




    void Update()
    {
        PauseMenu();
    }


    //===========================================
    // L  E  V  E  L    M  A  N  A  G  E  R
    //===========================================

    // Initiliazes general level elements and logic.
    public void Init_Level()
    {
        LevelUIPrefabGameObject = Instantiate(LevelUIPrefab);

        PauseMenuGameObject = LevelUIPrefabGameObject.GetComponent<LevelUILogic>().PauseMenu;

        PauseMenuGameObject.SetActive(false);
    }

    //===========================================
    //===========================================
    //===========================================


    //================
    // M  I  S  C
    //================

    // Logic for pausing and un-pausing the game.
    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Un-pause game
            if (PauseMenuGameObject.activeSelf) 
            {
                isGamePaused = false;
                PauseMenuGameObject.SetActive(false);
                Time.timeScale = 1.0f;
            }
            // Pause game
            else
            {
                isGamePaused = true;
                PauseMenuGameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }


    public void resetGameData()
    {
        hasRepairHammer = false;
        healthPotCount = 0;
        isGameOver = false;
        isGamePaused = false;
        isLevelOver = false;
    }

    //=======================
    //  GETTER AND SETTERS
    //=======================
    //==Getter and Setters for the player weapon inventory==//

    public List<WeaponObject> getPlayerWeaponInventory()
    {
        return playerWeaponInventory;
    }
    public void setPlayerWeaponInventory(List<WeaponObject> weaponList)
    {
        playerWeaponInventory = weaponList;
    }
    public GameObject getEquippedWeapon()
    {
        return equippedWeapon;
    }
    public void setEquippedWeapon(GameObject weapon)
    {
        equippedWeapon = weapon;
    }
    public WeaponObject getDefaultWeapon()
    {
        return defaultWeapon;
    }
    public WeaponObject getDefaultShield()
    {
        return defaultShield;
    }
    public List<WeaponObject> getWeaponScriptObjList()
    {
        return weaponScriptObjList;
    }

    //public WeaponObject getRepairHammerObj()
    //{
    //    return repairHammerObj;
    //}
    //public WeaponObject getHealthPotObj()
    //{
    //    return healthPotObj;
    //}
    //public void setHealthPotObj(WeaponObject wo)
    //{
    //    healthPotObj = wo;
    //}
    //====================//
    public void setHasRepairHammer(bool h)
    {
        hasRepairHammer = h;
    }
    public bool getHasRepairHammer()
    {
        return hasRepairHammer;
    }
    public void addHealthPotion()
    {
        healthPotCount++;
    }
    public void subHealthPotion()
    {
        healthPotCount--;
    }
    public int getHealthPotCount()
    {
        return healthPotCount;
    }
    public void setHealthPotCount(int cnt)
    {
        healthPotCount = cnt;
    }
    public bool getIsGameOver()
    {
        return isGameOver;
    }
    public void setIsGameOver(bool isGO)
    {
        isGameOver = isGO;
    }
    public bool getIsGamePaused()
    {
        return isGamePaused;
    }
    public void setIsGamePaused(bool isGP)
    {
        isGamePaused = isGP;
    }
    public List<int> getListOfSceneOrder()
    {
        return listOfRandomSceneOrder;
    }
    public void setListOfSceneOrder(List<int> order)
    {
        listOfRandomSceneOrder = order;
    }
    public void setIsLevelOver(bool isLO)
    {
        isLevelOver = isLO;
    }
    public bool getIsLevelOver()
    {
        return isLevelOver;
    }
    public void setIsGameWon(bool isGW)
    {
        isGameWon = isGW;
    }
    public bool getIsGameWon()
    {
        return isGameWon;
    }
    //================
    //================
    //================
}
