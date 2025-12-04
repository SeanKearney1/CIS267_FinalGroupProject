using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class UI_Sidebar : MonoBehaviour
{
    //==PUBLIC==//
    public static UI_Sidebar sbInstance { get; private set; }
    [Header("--Tower Type Buttons--")]
    public List<TMP_Text> towerTypeTextList;

    [Header("--Tower Slots--")]
    public List<Button> towerSelectBtnList;
    public List<TMP_Text> towerBtnTextList;
    public List<TMP_Text> towerSelKeyTextList;

    [Header("--Usable Tower Lists--")]
    public List<GameObject> orcUsableTowerList;
    public List<GameObject> elvenUsableTowerList;
    public List<GameObject> dwarvenUsableTowerList;

    //==PRIVATE==//
    private TilePlacment placementScript;
    private UI_TowerInfoDisplay towerInfoDisplay;
    private bool isOrcSelected;
    private bool isDwarvenSelected;
    private bool isElvenSelected;
    private bool isTowerSelected;
    private int previousSelection;
    private int typeSelection;



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
        isTowerSelected = false;
        placementScript = FindAnyObjectByType<TilePlacment>();
        towerInfoDisplay = GetComponent<UI_TowerInfoDisplay>();
        typeSelection = 0;
        orcTowersSelected();
    }
    private void Update()
    {
        towerTypeKeyBindings();
        deSelectKeyBindings();
        if(Input.anyKeyDown)
        {
            towerSelKeyBindings();
        }
    }
    //used to pass the sidebar button click index to the tile placement script 
    public void towerSelection(int index)
    {
        towerSelKeyTextList[index].color = Color.red;
        isTowerSelected = true; //true = can now build/place a tower
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
    //======These following functions are used to populate the Sidebar==//
    //======depending on the type selected=============================//
    public void orcTowersSelected()
    {
        towerTypeTextList[0].color = Color.red;
        towerTypeTextList[1].color = Color.white;
        towerTypeTextList[2].color = Color.white;
        typeSelection = 0;
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
        typeSelection = 1;
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
        typeSelection = 2;
        if (elvenUsableTowerList != null)
        {
            isOrcSelected = false;
            isDwarvenSelected = false;
            isElvenSelected = true;
            for (int i = 0; i < elvenUsableTowerList.Count; i++)
            {
                Sprite towerSprite = elvenUsableTowerList[i].GetComponent<TowerData>().getTowerHeadSprite();
                string tName = elvenUsableTowerList[i].GetComponent<TowerData>().getTowerName();
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
    //================================================//
    private void towerSelKeyBindings()
    {
        for (int i = 0; i < 4; i++)
        {
            towerSelKeyTextList[previousSelection].color = Color.white;
            if (Input.GetKeyDown(KeyCode.F1 + i))
            {
                previousSelection = i;
                Debug.Log("SideBar Sel: " + i);
                towerSelectBtnList[i].onClick.Invoke();
                towerSelKeyTextList[i].color = Color.red;
                //return i;
            }
        }
        //return 0;
    }
    private void towerTypeKeyBindings()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            typeSelection++;
            if(typeSelection > 2)
            {
                typeSelection = 0;
            }
            if(typeSelection == 0)
            {
                orcTowersSelected();
            }
            else if(typeSelection == 1)
            {
                dwarvenTowersSelected();
            }
            else if(typeSelection == 2)
            {
                elvenTowersSelected();
            }
        }
    }
    //used to deselect the current tower before building it by right clicking
    private void deSelectKeyBindings()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isTowerSelected = false;
        }
    }
    public void resetTowerSelText()
    {
        //used to reset the text color
        foreach (TMP_Text text in towerSelKeyTextList)
        {
            text.color = Color.white;
        }
    }

    public void towerSelOnMouseEnter(int towerIndex)
    {
        Debug.Log("towerIndex - " + towerIndex);
        if (isOrcSelected)
        {
            towerInfoDisplay.setTowerData(orcUsableTowerList[towerIndex].GetComponent<TowerData>());
            towerInfoDisplay.setInfoPanelActivity(true);
        }
        else if (isDwarvenSelected)
        {
            towerInfoDisplay.setTowerData(dwarvenUsableTowerList[towerIndex].GetComponent<TowerData>());
            towerInfoDisplay.setInfoPanelActivity(true);
        }
        else if(isElvenSelected)
        {
            towerInfoDisplay.setTowerData(elvenUsableTowerList[towerIndex].GetComponent<TowerData>());  
            towerInfoDisplay.setInfoPanelActivity(true);
        }
    }
    public void towerSelOnMouseExit()
    {
        towerInfoDisplay.setInfoPanelActivity(false);
    }

    //======= SETTERS / GETTERS =========//
    public void setIsTowerSelected(bool clicked)
    {
        isTowerSelected = clicked;
    }
    public bool getIsTowerSelected()
    {
        return isTowerSelected;
    }



}
