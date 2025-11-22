using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Collections.Generic;


public class UI_Hotbar : MonoBehaviour
{


    [Header("--Hotbar Slots--")]
    public List<GameObject> listOfQuickSlots;

    private List<GameObject> listOfInventory;

    void Start()
    {
        listOfInventory = new List<GameObject>();

        // could maybe be place else where 
        ResetHotBar();
    }

    void Update()
    {
        
    }

    //used to update the quick slots when a new item is picked up
    private void UpdateQuickSlots()
    {
        if(listOfInventory != null)
        {
            for(int i = 0; i <  listOfInventory.Count; i++)
            {
                Sprite tempSprite = listOfInventory[i].GetComponent<SpriteRenderer>().sprite;
                Image quickSlot = listOfQuickSlots[i].GetComponent<Image>();
                Color tempC = quickSlot.color; //next 3 lines are for adjusting the color.alpha  
                tempC.a = 1f;                  
                quickSlot.color = tempC; 
                quickSlot.sprite = tempSprite;
                quickSlot.preserveAspect = true;
                Debug.Log("updated quick slots");
            }
        }
    }


    // Used to reset the quickslots on a new load or restart
    private void ResetHotBar()
    {
        if(listOfQuickSlots != null )
        {
            foreach(GameObject go in listOfQuickSlots)
            {
                Color tempC = go.GetComponent<Image>().color;
                tempC.a = 0f;
                go.GetComponent<Image>().color = tempC;
                go.GetComponent<Image>().sprite = null;
            }
        }
    }

    public void SetListOfInventroy(List<GameObject> list)
    {
        listOfInventory = list;
        Debug.Log("list count: " + listOfQuickSlots.Count);
        UpdateQuickSlots();
    }
}
