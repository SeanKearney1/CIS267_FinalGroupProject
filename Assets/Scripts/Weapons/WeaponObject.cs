using NUnit.Framework;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponObject", menuName = "Scriptable Objects/WeaponObject")]
public class WeaponObject : ScriptableObject
{
    public string weaponName; // could be used to assign a tag for later use with collisions
    public string weaponType; //type of weapon - sword/spear/bow/etc
    public int weaponDmg;     
    public float attackSpeed;
    public float weaponRange;
    public AudioClip weaponSound;
    public GameObject weaponPrefab;

    // only if we are able to buy weapons // if weapons are only picked up then this can be deleted
    public int weaponCost; 


}
