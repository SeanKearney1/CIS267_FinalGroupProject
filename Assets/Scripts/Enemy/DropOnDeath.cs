using Unity.VisualScripting;
using UnityEngine;

public class DropOnDeath : MonoBehaviour
{
    //Drops set item on enemy death

    [Header("--Item to Drop--")]
    public GameObject itemToDrop;
    [Header("--Item drop rate 10 = 10%--")]
    public int dropRate;

    private Vector2 dropPos;

    private void Update()
    {
        dropPos = gameObject.transform.position;
    }

    private void OnDestroy()
    {
        randomizeDrop();
    }

    private void dropItem()
    {
        Instantiate(itemToDrop);
        itemToDrop.transform.position = dropPos;
    }

    private void randomizeDrop()
    {
        int randomNum = Random.Range(0, 100);
        if(randomNum <= dropRate)
        {
            dropItem();
        }
    }

}
