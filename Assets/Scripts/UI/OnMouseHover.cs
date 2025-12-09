using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("--OnMouseEnterData--")]
    public int buttonIndex;
    public bool isSideBar;
    public bool isGuideMenu;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isSideBar)
        {
            UI_Sidebar.sbInstance.towerSelOnMouseEnter(buttonIndex);
        }
        else if(isGuideMenu)
        {
            GameObject mainParent = gameObject.transform.parent.parent.parent.gameObject;
            Debug.Log("parent name: " + mainParent.name + " - number: " + buttonIndex);
            mainParent.GetComponent<UI_GuideMenu>().onEnterTowerDisplay(buttonIndex);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSideBar)
        {
            UI_Sidebar.sbInstance.towerSelOnMouseExit();
        }
        else if (isGuideMenu)
        {
            GameObject mainParent = gameObject.transform.parent.parent.parent.gameObject;
            mainParent.GetComponent<UI_GuideMenu>().onExitTowerDisplay();
        }
    }
}
