using UnityEngine;

public class UI_GuideMenu : MonoBehaviour
{
    [Header("--List Of Towers--")]
    public GameObject[] listOfTowers;

    private UI_TowerInfoDisplay towerDisplay;
    private int towerIndex;
    


    void Start()
    {
        towerDisplay = GetComponent<UI_TowerInfoDisplay>();
    }


    void Update()
    {
        
    }

    public void onEnterTowerDisplay(int tIndex)
    {
        towerIndex = tIndex;
        towerDisplay.setTowerData(listOfTowers[towerIndex].GetComponent<TowerData>());
        towerDisplay.setInfoPanelActivity(true);
    }
    public void onExitTowerDisplay()
    {
        towerDisplay.setInfoPanelActivity(false);
    }

    //public void towerSelOnMouseEnter(int towerIndex)
    //{
    //    Debug.Log("towerIndex - " + towerIndex);
    //    if (isOrcSelected)
    //    {
    //        towerInfoDisplay.setTowerData(orcUsableTowerList[towerIndex].GetComponent<TowerData>());
    //        towerInfoDisplay.setInfoPanelActivity(true);
    //    }
    //    else if (isDwarvenSelected)
    //    {
    //        towerInfoDisplay.setTowerData(dwarvenUsableTowerList[towerIndex].GetComponent<TowerData>());
    //        towerInfoDisplay.setInfoPanelActivity(true);
    //    }
    //    else if (isElvenSelected)
    //    {
    //        towerInfoDisplay.setTowerData(elvenUsableTowerList[towerIndex].GetComponent<TowerData>());
    //        towerInfoDisplay.setInfoPanelActivity(true);
    //    }
    //}
}
