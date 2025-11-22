using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    //================================================//
    //                 PUBLIC                         //
    //================================================//

    // Scriptable Objects for each weapon
    // Each hold the data for that weapon
    // I just added some random types for now
    // This could also be a list instead of separate objects if we want to.
    [Header("--Weapon Objects--")]
    public WeaponObject swordObj;
    public WeaponObject cutlassObj;
    public WeaponObject spearObj;
    public WeaponObject staffObj;
    public WeaponObject clubObj;
    public WeaponObject bowObj;


    // gameObject where the weapon will spawn in at
    // likly located on the players hand
    [Header("--Weapon Spawn--")]
    public GameObject weaponSpawnLocation;

    // UI hotbar gameobject used to access the UI_hotbar script
    [Header("--UI_Hotbar--")]
    public GameObject hotbarObject;


    //================================================//
    //                 PRIVATE                        //
    //================================================//

    //===Weapon Data===//
    private WeaponObject equippedWeapon;
    private string equippedName;
    private string equippedType;
    private int equippedDmg;
    private float equippedAttackSpeed;
    private float equippedRange;


    private List<GameObject> listOfWeaponInventory;
    private GameObject initWeapon;



    void Start()
    {
        listOfWeaponInventory = new List<GameObject>();
        AddWeaponToInventory(InitDefaultWeapon());

    }



    // Initializes and returns the default weapon
    // Default = basic sword for now
    // but could be a List<WeaponObject> later for possible features later on
    // Used to spawn the default weapon at the start of the level
    // Might make a function for each weapon or just use a List and pass and arg 
    // then arg = which weapon to spawn. Maybe base it off the weapon name.
    public GameObject InitDefaultWeapon()
    {
        GameObject tempWeapon = cutlassObj.weaponPrefab;
        equippedWeapon = cutlassObj;
        InitEquippedWeaponData(swordObj);
        float x = weaponSpawnLocation.transform.position.x;
        float y = weaponSpawnLocation.transform.position.y;
        Vector3 pos = new Vector3(x, y, 0f);
        initWeapon = Instantiate(tempWeapon, pos, Quaternion.identity, weaponSpawnLocation.transform);
        return initWeapon; 
    }

    public void AddWeaponToInventory(GameObject weapon)
    {
        // Can only have 1 of each weapon I'm guessing
        // This check to see if weapon is already in the players inventory
        if(!listOfWeaponInventory.Contains(weapon))
        {
            //disables the collider used to collect the weapon // this might be better somewhere else
            weapon.GetComponent<CapsuleCollider2D>().enabled = false;
            listOfWeaponInventory.Add(weapon);
            hotbarObject.GetComponent<UI_Hotbar>().SetListOfInventroy(listOfWeaponInventory);
            //call function here to update the weapon hotbar on the GUI
            Debug.Log("weapon cnt: " + listOfWeaponInventory.Count);
        }
    }

    // Initializes the equipped weapon data
    // could also just pass the Scriptable Object with a getter
    // then just access the data through that when its needed
    private void InitEquippedWeaponData(WeaponObject wObj)
    {
        equippedName = swordObj.weaponName;
        equippedType = swordObj.weaponType;
        equippedDmg = swordObj.weaponDmg;
        equippedAttackSpeed = swordObj.attackSpeed;
        equippedRange = swordObj.weaponRange;
    }

    //this could be used instead of above (InitEquippedWeaponData)
    public WeaponObject GetEquippedWeaponObj()
    {
        return equippedWeapon;
    }

    public List<GameObject> GetListOfWeaponInventory()
    {
        return listOfWeaponInventory;
    }
}
