using TMPro;
using UnityEngine;

public class UI_TowerInfoDisplay : MonoBehaviour
{
    //==PUBLIC==//
    [Header("--Panel Text Fields--")]
    public GameObject displayPanel; //panel with info to be displayed
    public TMP_Text towerNameTxt;
    public TMP_Text towerCostTxt;
    public TMP_Text towerDamageTxt;
    public TMP_Text towerAttackSpeedTxt;
    public TMP_Text towerRangeTxt;
    public TMP_Text towerHealthTxt;
    public TMP_Text towerVitalityTxt;
    public TMP_Text towerResistanceTxt;

    //==PRIVATE==//
    private string towerName;
    private int towerCost;
    private float towerDamage;
    private float towerAttackSpeed;
    private float towerRange;
    private float towerHealth;
    private float towerVitality;
    private float towerResistance;

    public void setTowerData(TowerData tData)
    {
        towerName = tData.getTowerName();
        towerCost = tData.getTowerCost();
        towerDamage = tData.getTowerDmg();
        towerAttackSpeed = tData.getTowerAtkSpeed();
        towerRange = tData.getTowerRange();
        towerHealth = tData.getTowerHealth();
        towerVitality = tData.getTowerVitality();
        towerResistance = tData.getTowerResistance();
        setTowerDataTxt();
    }

    private void setTowerDataTxt()
    {
        towerNameTxt.text = towerName;
        towerCostTxt.text = towerCost.ToString();
        towerDamageTxt.text = towerDamage.ToString();
        towerAttackSpeedTxt.text = towerAttackSpeed.ToString();
        towerRangeTxt.text = towerRange.ToString();
        towerHealthTxt.text = towerHealth.ToString();
        towerVitalityTxt.text = towerVitality.ToString();
        towerResistanceTxt.text = towerResistance.ToString();
    }
    public void setInfoPanelActivity(bool act)
    {
        displayPanel.SetActive(act);
    }
}
