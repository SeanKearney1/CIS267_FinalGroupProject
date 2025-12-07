using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Collections.Generic;


public class UI_Hotbar : MonoBehaviour
{
    // UI_Hotbar Singleton 
    public static UI_Hotbar hbInstance {  get; private set; }
    
    //==PUBLIC==//
    [Header("--Hotbar Slots--")]
    public List<GameObject> quickSlotList; //maybe this could be an array since its a static 6 slots
    [Header("--Side Slots--")]
    public GameObject hammerSlot;
    public GameObject extraSlot;
    [Header("--Slot Backgrounds--")]
    public Sprite darkHighlighedSlot;
    public Sprite darkNormalSlot;
    public Sprite lightHighlightedSlot;
    public Sprite lightNormalSlot;


    //==PRIVATE==//
    private List<WeaponObject> weaponObjInventoryList = new List<WeaponObject>();
    private WeaponObject repairHammer;
    private WeaponObject extraObject;
    private int selectedSlot;

   
    private void Awake()
    {   // Ensuring this hbInstance is the only one
        if (hbInstance != null && hbInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        hbInstance = this;
    }

    void Start()
    {
        selectedSlot = 6;
        //currentWaveCount = 1;
        //gets the default weapon inventory on load and update the hotbar
        setListOfInventory(GameManagerLogic.Instance.getPlayerWeaponInventory());
        highlightSelectedWeapon(1);
    }
    //used to get which hot bar key was selected 1-10 though only 1-6 is used
    public int hotbarSelection()
    {
        for (int i = 0; i < 7; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                Debug.Log("hotbarSel: " + i);
                return i;
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("SEVEN");
            return 7;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            return 8;
        }
        return 0;

    }

    //used to update the quick slots when a new item is picked up
    private void updateQuickSlots()
    {
        if(weaponObjInventoryList != null)
        {
            for(int i = 0; i <  weaponObjInventoryList.Count; i++)
            {
                Sprite tempSprite = weaponObjInventoryList[i].weaponSprite;
                Image quickSlot = quickSlotList[i].GetComponent<Image>();
                Color tempC = quickSlot.color; //next 3 lines are for adjusting the color.alpha  
                tempC.a = 1f;                  //when alpha = 1 and no sprite the background is default white
                quickSlot.color = tempC;       //so alpha is set to 0 until a weapon is in that slot
                quickSlot.sprite = tempSprite; //this doesn't reset back to 0 since we keep the weapon
                quickSlot.preserveAspect = true;
                //Debug.Log("updatedQuickSlots");
            }
        }
        if (repairHammer != null)
        {
            Sprite tempSrite = repairHammer.weaponSprite;
            Image hSlot = hammerSlot.GetComponent<Image>();
            Color tempC = hSlot.color;
            tempC.a = 1f;
            hSlot.color = tempC;
            hSlot.sprite = tempSrite;
        }
        if(extraObject != null)
        {

        }
    }

    public void highlightSelectedWeapon(int sel)
    {
        // only using the dark slot for now but added a light one for the heck of it
        if (sel != selectedSlot)
        {
            Image slotImg = null;
            if(selectedSlot == 7)
            {
                slotImg = hammerSlot.transform.parent.GetComponent<Image>();
                slotImg.sprite = darkNormalSlot;
            }
            else if(selectedSlot == 8)
            {
                slotImg = extraSlot.transform.parent.GetComponent<Image>();
                slotImg.sprite = darkNormalSlot;
            }
            else
            {
                // reset the sprite to the normal slot
                slotImg = quickSlotList[selectedSlot - 1].transform.parent.GetComponentInParent<Image>();
                slotImg.sprite = darkNormalSlot;
            }
            if (sel == 7)
            {
                // highlights the repair hammer
                slotImg = hammerSlot.transform.parent.GetComponentInParent<Image>();
                slotImg.sprite = darkHighlighedSlot;
                selectedSlot = sel;
            }
            else if (sel == 8)
            {
                //hightlight extra slot
                // highlights the repair hammer
                slotImg = extraSlot.transform.parent.GetComponentInParent<Image>();
                slotImg.sprite = darkHighlighedSlot;
                selectedSlot = sel;
            }
            else
            {
                // set the sprite to the highlighted spot
                slotImg = quickSlotList[sel - 1].transform.parent.GetComponentInParent<Image>();
                slotImg.sprite = darkHighlighedSlot;
                selectedSlot = sel;

            }
        }
    }

    public void setListOfInventory(List<WeaponObject> list)
    {
        weaponObjInventoryList = list;
        updateQuickSlots();
        //Debug.Log("setListOfInventory.count: " + quickSlotList.Count);
    }
    public void setRepairHammerObj(WeaponObject hammer)
    {
        repairHammer = hammer;
        updateQuickSlots();
        //update the side slot
    }
}
