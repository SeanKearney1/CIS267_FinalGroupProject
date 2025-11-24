using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Collections.Generic;


public class UI_Hotbar : MonoBehaviour
{
    public static UI_Hotbar hbInstance {  get; private set; }
    


    [Header("--Hotbar Slots--")]
    public List<GameObject> quickSlotList;
    public Sprite darkHighlighedSlot;
    public Sprite darkNormalSlot;
    public Sprite lightHighlightedSlot;
    public Sprite lightNormalSlot;
    private List<WeaponObject> weaponObjInventoryList;
    private int selectedSlot;


    private void Awake()
    {
        if (hbInstance != null && hbInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        hbInstance = this;
        weaponObjInventoryList = new List<WeaponObject>();
    }

    void Start()
    {
        //gets the weapon inventory on load and update the hotbar
        selectedSlot = 6;
        setListOfInventory(GameManagerLogic.Instance.getPlayerWeaponInventory());
        highlightSelectedWeapon(1);
    }

    void Update()
    {
        
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
    }

    public void highlightSelectedWeapon(int sel)
    {
        // only using the dark slot for now but added a light one for the heck of it
        if (sel != selectedSlot)
        {
            // reset the sprite to the normal slot
            Image slotImg = quickSlotList[selectedSlot - 1].transform.parent.GetComponentInParent<Image>();
            slotImg.sprite = darkNormalSlot; //


            // set the sprite to the highlighted spot
            slotImg = quickSlotList[sel - 1].transform.parent.GetComponentInParent<Image>();
            slotImg.sprite = darkHighlighedSlot;
            selectedSlot = sel;
        }
    }

    public void setListOfInventory(List<WeaponObject> list)
    {
        weaponObjInventoryList = list;
        updateQuickSlots();
        //Debug.Log("setListOfInventory.count: " + quickSlotList.Count);
    }
}
