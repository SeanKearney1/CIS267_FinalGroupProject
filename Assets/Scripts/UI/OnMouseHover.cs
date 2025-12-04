using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonIndex;

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Sidebar.sbInstance.towerSelOnMouseEnter(buttonIndex);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Sidebar.sbInstance.towerSelOnMouseExit();
        //buttonIndex = 0;
    }
}
