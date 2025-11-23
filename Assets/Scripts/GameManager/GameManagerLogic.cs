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
    public GameObject LevelUIPrefab;
    public static GameManagerLogic Instance { get; private set; }



    // PRIVATE
    private GameObject LevelUIPrefabGameObject;
    private GameObject PauseMenuGameObject;

    // For weapon handling 
    private List<WeaponObject> playerWeaponInventory;
    private GameObject equippedWeapon;

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
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
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
            if (PauseMenuGameObject.activeSelf) {
                PauseMenuGameObject.SetActive(false); 
                Time.timeScale = 1.0f;
            }
            // Pause game
            else
            {
                PauseMenuGameObject.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }


    //==Getter and Setters for the player weapon inventory==//
    public List<WeaponObject> getPlayerWeaponInventory()
    {
        return playerWeaponInventory;
    }
    public void setPlayerWeaponInventory(List<WeaponObject> weaponList)
    {
        playerWeaponInventory = weaponList;
    }
    //==Getter and Setters for the equipped player weapon==//
    public GameObject getEquippedWeapon()
    {
        return equippedWeapon;
    }
    public void setEquippedWeapon(GameObject weapon)
    {
        equippedWeapon = weapon;
    }

    //================
    //================
    //================
}
