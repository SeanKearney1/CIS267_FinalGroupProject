using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UI_Sidebar : MonoBehaviour
{
    //==PUBLIC==//
    public static UI_Sidebar sbInstance { get; private set; }
    [Header("--Tower Type Buttons--")]
    public List<TMP_Text> towerTypeTextList;

    [Header("--Tower Slots--")]
    public List<Button> towerSelectBtnList;
    public List<TMP_Text> towerBtnTextList;

    [Header("--Usable Tower Lists--")]
    public List<GameObject> orcUsableTowerList;
    public List<GameObject> elvenUsabelTowerList;
    public List<GameObject> dwarvenUsableTowerList;

    //==PRIVATE==//
    private TilePlacment placementScript;
    private bool isOrcSelected;
    private bool isDwarvenSelected;
    private bool isElvenSelected;



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
        placementScript = FindAnyObjectByType<TilePlacment>();
        orcTowersSelected();
    }
    public void towerSelection(int index)
    {
        if (isOrcSelected)
        {
            Debug.Log("Testing Orc: " + index);
            placementScript.switchSelection(index);
        }
        else if (isDwarvenSelected)
        {
            Debug.Log("Testing Dwarven: " + (index + orcUsableTowerList.Count));
            placementScript.switchSelection(index + orcUsableTowerList.Count);
        }
        else if (isElvenSelected)
        {
            Debug.Log("Testing Elven: " + (index + orcUsableTowerList.Count + dwarvenUsableTowerList.Count));
            placementScript.switchSelection(index + orcUsableTowerList.Count + dwarvenUsableTowerList.Count);
        }
    }
    public void orcTowersSelected()
    {
        towerTypeTextList[0].color = Color.red;
        towerTypeTextList[1].color = Color.white;
        towerTypeTextList[2].color = Color.white;
        if (orcUsableTowerList != null)
        {
            isOrcSelected = true;
            isDwarvenSelected = false;
            isElvenSelected = false;
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
            isOrcSelected = false;
            isDwarvenSelected = true;
            isElvenSelected = false;
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
            isOrcSelected = false;
            isDwarvenSelected = false;
            isElvenSelected = true;
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
