using UnityEngine;

public class TowerData : MonoBehaviour
{
    [Header("--Tower Details for Sidebar--")]
    public string towerName;
    public Sprite towerHeadSprite;

    public string getTowerName()
    {
        return towerName;
    }
    public Sprite getTowerHeadSprite()
    {
        return towerHeadSprite;
    }





}
