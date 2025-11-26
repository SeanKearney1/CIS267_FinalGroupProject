using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UI_Sidebar : MonoBehaviour
{
    public static UI_Sidebar sbInstance {  get; private set; }

    // Might be better to just get and use the TMP_Text when the button itself is changed
    // Then the extra textList wouldn't be needed

    [Header("--Select Tower Type Buttons--")]
    public List<Button> selTowerTypeBtnList; // might not need this
    public List<TMP_Text> towerTypeTextList;

    [Header("--Tower Slots--")]
    public List<Button> towerSelectBtnList; 
    public List<TMP_Text> towerBtnTextList;

    [Header("--Usable Tower Lists--")]
    public List<GameObject> orcUsableTowerList;
    public List<GameObject> elvenUsabelTowerList;
    public List<GameObject> dwarvenUsableTowerList;



    private void Awake()
    {
        if (sbInstance != null && sbInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        sbInstance = this;
    }

    void Start()
    {
        //set/add default tower
        orcTowersSelected();
    }

    void Update()
    {
        
    }
    public void orcTowersSelected()
    {
        towerTypeTextList[0].color = Color.red;
        towerTypeTextList[1].color = Color.white;
        towerTypeTextList[2].color = Color.white;
        if (orcUsableTowerList != null)
        {
            for (int i = 0; i < orcUsableTowerList.Count; i++)
            {
                Sprite towerSprite = orcUsableTowerList[i].GetComponent<TowerData>().getTowerHeadSprite();
                string tName = orcUsableTowerList[i].GetComponent<TowerData>().getTowerName();
                Image tempImg = towerSelectBtnList[i].GetComponent<Image>();
                Color tempC = tempImg.color;
                tempC.a = 1f;
                tempImg.color = tempC;
                tempImg.sprite = towerSprite;
                tempImg.preserveAspect = true;
                towerBtnTextList[i].text = tName;
            }
        }
    }
    public void dwarvenTowersSelected()
    {
        towerTypeTextList[0].color = Color.white;
        towerTypeTextList[1].color = Color.red;
        towerTypeTextList[2].color = Color.white;
        if (dwarvenUsableTowerList != null)
        {
            for (int i = 0; i < dwarvenUsableTowerList.Count; i++)
            {
                Sprite towerSprite = dwarvenUsableTowerList[i].GetComponent<TowerData>().getTowerHeadSprite();
                string tName = dwarvenUsableTowerList[i].GetComponent<TowerData>().getTowerName();
                Image tempImg = towerSelectBtnList[i].GetComponent<Image>();
                Color tempC = tempImg.color;
                tempC.a = 1f;
                tempImg.color = tempC;
                tempImg.sprite = towerSprite;
                tempImg.preserveAspect = true;
                towerBtnTextList[i].text = tName;
            }
        }
    }
    public void elvenTowersSelected()
    {
        towerTypeTextList[0].color = Color.white;
        towerTypeTextList[1].color = Color.white;
        towerTypeTextList[2].color = Color.red;
        if (elvenUsabelTowerList != null)
        {
            for (int i = 0; i < elvenUsabelTowerList.Count; i++)
            {
                Sprite towerSprite = elvenUsabelTowerList[i].GetComponent<TowerData>().getTowerHeadSprite();
                string tName = elvenUsabelTowerList[i].GetComponent<TowerData>().getTowerName();
                Image tempImg = towerSelectBtnList[i].GetComponent<Image>();
                Color tempC = tempImg.color;
                tempC.a = 1f;
                tempImg.color = tempC;
                tempImg.sprite = towerSprite;
                tempImg.preserveAspect = true;
                towerBtnTextList[i].text = tName;
            }
        }
    }


}
