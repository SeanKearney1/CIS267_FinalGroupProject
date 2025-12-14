using Mono.Cecil.Cil;
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
    //[Header("--Weapon Objects--")]
    //public List<WeaponObject> listOfWeaponScriptObject;


    // gameObject where the weapon will spawn in at
    // likly located on the players hand
    [Header("--Weapon/Shield Spawn--")]
    public GameObject weaponSpawnLocation;
    public GameObject shieldSpawnLocation;
    public GameObject weaponSights;



    //================================================//
    //                 PRIVATE                        //
    //================================================//

    //===Weapon data for the currently equipped weapon===//
    private WeaponObject currentWeapon;
    private WeaponObject currentShield;

    // might not need these vars if we access the data via currentWeapon.weaponName etc...
    private string currWeaponName;
    private string currWeaponType;
    private int currWeaponDamage;
    private float currWeaponAttackSpeed;
    private float currWeaponRange;

    private List<WeaponObject> listOfWeaponScriptObject = new List<WeaponObject>();
    private List<WeaponObject> weaponInventoryList = new List<WeaponObject>();
    private WeaponObject repairHammer = null;
    private WeaponObject healthPot = null;
    private GameObject initWeapon;
    private GameObject initSights;
    //private bool hasHammer;

    void Start()
    {

        // Default = cutlassObj for now
        // default for first ever load
        // then using game manager or ui_hotbar to keep track of the equipped weapon
        // so if the player dies and respawns the previous 
        // weapon inventory is reload with the player.
        listOfWeaponScriptObject = GameManagerLogic.Instance.getWeaponScriptObjList();
        //respawnPlayerInventory();
        //WeaponObject defWeapon = GameManagerLogic.Instance.getDefaultWeapon();
        //addWeaponToInventory(defWeapon.weaponName);
        //addHammerToInventory(GameManagerLogic.Instance.getRepairHammerObj().weaponName);
        weaponInventoryList = GameManagerLogic.Instance.getPlayerWeaponInventory();
        UI_Hotbar.hbInstance.setListOfInventory(weaponInventoryList);
        initializeWeapon(weaponInventoryList[0]);
    }
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            weaponSelect(UI_Hotbar.hbInstance.hotbarSelection());
            //hammerSelected(UI_Hotbar.hbInstance.hotbarSelection());
        }
    }
    public void respawnPlayerInventory()
    {
        weaponInventoryList = GameManagerLogic.Instance.getPlayerWeaponInventory();
        UI_Hotbar.hbInstance.setListOfInventory(weaponInventoryList);
    }
    //used to switch from the old equipped weapon to the new one
    public void weaponSelect(int sel)
    {
        //theres probably a better way to error check this
        if (weaponInventoryList.Count >= sel && sel != 0)
        {
            Destroy(weaponSpawnLocation.transform.GetChild(0).gameObject);
            initializeWeapon(weaponInventoryList[sel - 1]);
            UI_Hotbar.hbInstance.highlightSelectedWeapon(sel);
        }
        else if(sel == 7)
        {
            if (repairHammer != null)
            {
                Destroy(weaponSpawnLocation.transform.GetChild(0).gameObject);
                initializeWeapon(repairHammer);
                UI_Hotbar.hbInstance.highlightSelectedWeapon(sel);
            }
        }
    }
    // Initializes the passed weapon scriptable object into the game world
    // Spawning the weapon into the player's "hands" 
    private void initializeWeapon(WeaponObject weapon)
    {
        if (weapon != null)
        {
            GameObject tempWeapon = weapon.weaponPrefab;
            currentWeapon = weapon;
            weaponTypeCheck(weapon); //check if weapon is 1H or 2H - if 1H it initializes a shield too
            initWeaponData(currentWeapon);
            float x = weaponSpawnLocation.transform.position.x;
            float y = weaponSpawnLocation.transform.position.y;
            Vector3 pos = new Vector3(x, y, 0f);
            initWeapon = Instantiate(tempWeapon, pos, Quaternion.identity, weaponSpawnLocation.transform);
            //initStaff(weapon, initWeapon);
            Vector3 newRotation = new Vector3(0f, 0f, 0f);
            Vector3 oldRotation = initWeapon.transform.rotation.eulerAngles;
            initWeapon.transform.localRotation = Quaternion.FromToRotation(oldRotation, newRotation);
            initWeapon.name = weapon.weaponName;
            if(weapon.weaponType != "Ranged")
            {
                initWeapon.transform.GetChild(0).GetComponent<WeaponController>().setCurWeaponObj(weapon);
            }
            GameManagerLogic.Instance.setEquippedWeapon(initWeapon);
            //return initWeapon;
        }
        //return null;
    }
    private void initializeShield(WeaponObject shield)
    {
        GameObject tempShield = shield.weaponPrefab;
        currentShield = shield;
        float x = shieldSpawnLocation.transform.position.x;
        float y = shieldSpawnLocation.transform.position.y;
        Vector3 pos = new Vector3(x, y, 0f);
        initSights = Instantiate(tempShield, pos, Quaternion.identity, shieldSpawnLocation.transform);
        Vector3 newRotation = new Vector3(0f, 0f, 0f);
        Vector3 oldRotation = new Vector3(0f, 0f, 0f);
        initSights.transform.localRotation = Quaternion.FromToRotation(oldRotation, newRotation);
        initSights.name = shield.weaponName;
    }
    private void weaponTypeCheck(WeaponObject wObj)
    {
        if (shieldSpawnLocation.transform.childCount > 0)
        {
            GameObject shield = shieldSpawnLocation.transform.GetChild(0).gameObject;
            Destroy(shield);
        }
        if (wObj.weaponType == "1H") // spawn shield if 1 handed weapon
        {
            initializeShield(GameManagerLogic.Instance.getDefaultShield());
        }
        //else if(wObj.weaponType == "Staff")
        //{
        //    //initializeSights(wObj);
        //    PlayerController pController = GetComponent<PlayerController>();
        //    pController.setIsSwinging(false);
        //    GameObject tempMuzzle = wObj.weaponPrefab.transform.GetChild(0).gameObject;
        //    tempMuzzle.transform.GetChild(0).gameObject.SetActive(true);
        //    Debug.Log("typeCheck - active?: " + tempMuzzle.transform.GetChild(0).gameObject.activeSelf);
        //}
    }

    private void initStaff(WeaponObject wObj, GameObject gObj)
    {
        if (shieldSpawnLocation.transform.childCount > 0)
        {
            GameObject shield = shieldSpawnLocation.transform.GetChild(0).gameObject;
            Destroy(shield);
        }
        gObj.transform.GetChild(0).GetComponent<StaffController>().initializeStaff(wObj);
        PlayerController pController = GetComponent<PlayerController>();
        pController.setIsSwinging(false);
        GameObject tempMuzzle = wObj.weaponPrefab.transform.GetChild(0).gameObject;
        tempMuzzle.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("typeCheck - active?: " + tempMuzzle.transform.GetChild(0).gameObject.activeSelf);
    }
    //private void initializeSights(WeaponObject weaponObj)
    //{
    //    GameObject tempMuzzle = weaponObj.weaponPrefab.transform.GetChild(0).gameObject;
    //    float x = tempMuzzle.transform.position.x;
    //    float y = tempMuzzle.transform.position.y;
    //    Vector3 pos = new Vector3((x + 1.5f), y, 0f);
    //    initSights = Instantiate(weaponSights, pos, Quaternion.identity);//, tempMuzzle.transform);
    //    Vector3 newRotation = new Vector3(0f, 0f, 0f);
    //    Vector3 oldRotation = new Vector3(0f, 0f, 0f);
    //    initSights.transform.localRotation = Quaternion.FromToRotation(oldRotation, newRotation);
    //    //initSights.name = weaponObj.name;
    //}
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
            //Debug.Log("addWeaponToInventroy.weaponName: " + tempObj.name);
            // I see the weapons having 2 colliders 1st for pick up and 2nd for detecting a hit
            // this disables the 1st collider used to collect the weapon
            tempObj.weaponPrefab.GetComponent<CapsuleCollider2D>().enabled = false;
            weaponInventoryList.Add(tempObj);
            GameManagerLogic.Instance.setPlayerWeaponInventory(weaponInventoryList);
            UI_Hotbar.hbInstance.setListOfInventory(weaponInventoryList);
        }
    }
    public void addHammerToInventory(string wName)
    {
        //if player does not already have the hammer
        if (!GameManagerLogic.Instance.getHasRepairHammer()) 
        {
            WeaponObject tempHammer = convertWeaponNameToObject(wName);
            if(repairHammer == null)
            {
                tempHammer.weaponPrefab.GetComponent<CapsuleCollider2D>().enabled = false;
                repairHammer = tempHammer;
                //GameManagerLogic.Instance.setHasRepairHammer(true);
                UI_Hotbar.hbInstance.setRepairHammerObj(repairHammer);
            }
        }
    }
    public void addHealthPotToInventory(string wName)
    {
        if(healthPot == null)
        {
            WeaponObject tempHealthPot = convertWeaponNameToObject(wName);
            healthPot = tempHealthPot;
            UI_Hotbar.hbInstance.setHealthPotObj(healthPot);
        }
    }
    // Initializes the equipped weapon data
    private void initWeaponData(WeaponObject wObj)
    {
        currWeaponName = wObj.weaponName;
        currWeaponType = wObj.weaponType;
        currWeaponDamage = wObj.weaponDmg;
        currWeaponAttackSpeed = wObj.attackSpeed;
        currWeaponRange = wObj.weaponRange;
    }
    public WeaponObject getCurrentShieldObj()
    {
        return currentShield;
    }
    public WeaponObject getCurrentWeaponObj()
    {
        return currentWeapon;
    }
    public void setHealthPotObj(WeaponObject wo)
    {
        healthPot = wo;
    }


}
