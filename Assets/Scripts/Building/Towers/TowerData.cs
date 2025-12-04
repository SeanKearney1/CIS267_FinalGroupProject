using UnityEngine;

public class TowerData : MonoBehaviour
{
    [Header("--Tower Details for Sidebar--")]
    public string towerName;
    public int towerCost;
    public float towerDmg;
    public float towerAtkSpeed;
    public float towerRange;
    public float towerHealth;
    public float towerVitality;
    public float towerResistance;
    public Sprite towerHeadSprite;

    public string getTowerName()
    {
        return towerName;
    }
    public int getTowerCost()
    {
        return towerCost;
    }
    public float getTowerDmg()
    {
        return towerDmg;
    }
    public float getTowerAtkSpeed()
    {
        return towerAtkSpeed;
    }
    public float getTowerRange()
    {
        return towerRange;
    }
    public float getTowerHealth()
    {
        return towerHealth;
    }
    public float getTowerVitality()
    {
        return towerVitality;
    }
    public float getTowerResistance()
    {
        return towerResistance;
    }
    public Sprite getTowerHeadSprite()
    {
        return towerHeadSprite;
    }
}
