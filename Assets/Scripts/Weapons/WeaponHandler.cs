using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{


    // This Script is used to hold all the weapon objects to include
    // the players inventory of weapons and currently equipped weapon data
    // This also handles the spawning of the weapons

    //================================================//
    //                 PUBLIC                         //
    //================================================//

    // Scriptable Objects for each weapon
    // Each hold the data for that weapon
    // I just added some random types for now
    [Header("--Weapon Objects--")]
    public List<WeaponObject> listOfWeaponScriptObject;


    // gameObject where the weapon will spawn in at
    // likly located on the players hand
    [Header("--Weapon Spawn--")]
    public GameObject weaponSpawnLocation;



    //================================================//
    //                 PRIVATE                        //
    //================================================//

    //===Weapon data for the currently equipped weapon===//
    private WeaponObject currentWeapon;
    private string currWeaponName;
    private string currWeaponType;
    private int currWeaponDamage;
    private float currWeaponAttackSpeed;
    private float currWeaponRange;


    private List<WeaponObject> weaponInventoryList;
    private GameObject initWeapon;

    private int hbSelection;


    private void Awake()
    {
        weaponInventoryList = new List<WeaponObject>();
    }

    void Start()
    {

        // Default = cutlassObj for now
        // default for first ever load
        // then using game manager or ui_hotbar to keep track of the equipped weapon
        // so if the player dies and respawns the previous 
        // weapon inventory is reload with the player. 
        addWeaponToInventory("Cutlass");
        initializeWeapon(weaponInventoryList[0]);
        //spawn default weapon function here?
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            hotbarSelection();

        }
    }
    private void hotbarSelection()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                Debug.Log("hotbarSel: " + i);
                weaponSelect(i);
            }
        }
    }

    //used to switch from the old equipped weapon to the new one
    private void weaponSelect(int sel)
    {
        //theres probably a better way to error check this
        if (weaponInventoryList.Count >= sel && sel != 0)
        {
            Destroy(weaponSpawnLocation.transform.GetChild(0).gameObject);
            initializeWeapon(weaponInventoryList[sel - 1]);
            UI_Hotbar.hbInstance.highlightSelectedWeapon(sel);
        }
    }

    // Initializes and returns the default weapon
    // Used to spawn the default weapon at the start of the level
    private GameObject initializeWeapon(WeaponObject weapon)
    {
        if(weapon != null)
        {        
            GameObject tempWeapon = weapon.weaponPrefab;
            currentWeapon = weapon;
            initWeaponData(currentWeapon);
            float x = weaponSpawnLocation.transform.position.x;
            float y = weaponSpawnLocation.transform.position.y;
            Vector3 pos = new Vector3(x, y, 0f);
            initWeapon = Instantiate(tempWeapon, pos, Quaternion.identity, weaponSpawnLocation.transform);
            initWeapon.name = weapon.weaponName;
            GameManagerLogic.Instance.setEquippedWeapon(initWeapon);
            return initWeapon;
        }
        return null;
    }

    private WeaponObject convertWeaponNameToObject(string name)
    {
        foreach(WeaponObject wo in listOfWeaponScriptObject)
        {
            if(wo.weaponName == name)
            {
                return wo;
            }
        }
        return null;
    }

    public void addWeaponToInventory(string wName)
    {
        WeaponObject tempObj = convertWeaponNameToObject(wName);
        // Can only have 1 of each weapon I'm guessing
        // This checks to see if weapon is already in the players inventory
        if(!weaponInventoryList.Contains(tempObj))
        {
            Debug.Log("addWeaponToInventroy.weaponName: " + tempObj.name);
            // I see the weapons having 2 colliders 1 for pick up and 2 for detecting a hit
            // this disables the collider used to collect the 
            weaponInventoryList.Add(tempObj);
            GameManagerLogic.Instance.setPlayerWeaponInventory(weaponInventoryList);
            UI_Hotbar.hbInstance.setListOfInventory(weaponInventoryList);
        }
    }

    // Initializes the equipped weapon data
    // could also just pass the Scriptable Object with a getter
    // then just access the data through that when its needed
    private void initWeaponData(WeaponObject wObj)
    {
        currWeaponName = wObj.weaponName;
        currWeaponType = wObj.weaponType;
        currWeaponDamage = wObj.weaponDmg;
        currWeaponAttackSpeed = wObj.attackSpeed;
        currWeaponRange = wObj.weaponRange;
    }

    //this could be used instead of the above function (initWeaponData)
    public WeaponObject getEquippedWeaponObj()
    {
        return currentWeapon;
    }

    // could probably pass this to game manager
    // to help keep track of the weapon inventroy in between levels
    //public List<GameObject> getListOfWeaponInventory()
    //{
    //    return weaponInventoryList;
    //}
}
