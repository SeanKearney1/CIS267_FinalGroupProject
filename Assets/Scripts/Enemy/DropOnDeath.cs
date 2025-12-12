using Unity.VisualScripting;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    //Drops set item on enemy death

    [Header("--Item to Drop--")]
    public GameObject itemToDrop;

    [Header("--Item drop rate 10 = 10%--")]
    public int dropRate;

    private GameObject potionHolderObj;
    private Vector2 dropPos;

    private void Update()
    {
        //dropPos = gameObject.transform.position;
    }


    private void dropItem()
    {
        dropPos = gameObject.transform.position;
        Debug.Log("potionObj: " + potionHolderObj.name);
        Instantiate(itemToDrop, potionHolderObj.transform, true);
        itemToDrop.transform.position = dropPos;
    }

    public void randomizeDrop()
    {
        int randomNum = Random.Range(0, 100);
        if (randomNum <= dropRate)
        {
            dropItem();
        }
    }

    public void setPotionHolderObj(GameObject pHolder)
    {
        potionHolderObj = pHolder;
    }

}
