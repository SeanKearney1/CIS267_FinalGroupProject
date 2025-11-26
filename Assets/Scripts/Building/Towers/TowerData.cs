using UnityEngine;

public class TowerData : MonoBehaviour
{
    [Header("--Tower Details--")]
    public string towerName;
    public string towerType; //might not need this
    public Sprite towerHeadSprite;

    //subject to changed depending on our needs
    [Header("--Initial Tower Stats--")]
    public int towerDamage;
    public int towerHealth;
    public float towerFireRate;
    public float towerRange; // maybe could use this for different size ranges for differnt tower types


    //==Getters==//
    public string getTowerName()
    {
        return towerName;
    }
    public string getTowerType()
    {
        return towerType;
    }
    public int getTowerDamage()
    {
        return towerDamage;
    }
    public int getTowerHealth()
    {
        return towerHealth;
    }
    public float getTowerFireRate()
    {
        return towerFireRate;
    }
    public float getTowerRange()
    {
        return towerRange;
    }
    public Sprite getTowerHeadSprite()
    {
        return towerHeadSprite;
    }
    //==Setters==//

    //====MIGHT NOT NEED THESE====//
    // Tower name and type should never change everything else can be modified
    // Or kept at the initial stat then using a multiplier in the individual tower script to 
    // change/modify the current stats
    //
    //public void setTowerName(string name)
    //{
    //    towerName = name;
    //}
    //public void setTowerType(string type)
    //{
    //    towerType = type;
    //}
    //============================//

    public void setTowerDamage(int dmg)
    {
        towerDamage = dmg;
    }
    public void setTowerHealth(int health)
    {
        towerHealth = health;
    }
    public void setTowerFireRate(float rate)
    {
        towerFireRate = rate;
    }
    public void setTowerRange(float range)
    {
        towerRange = range;
    }




}
