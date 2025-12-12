using UnityEngine;

public class EmptyObjectsHolder : MonoBehaviour
{
    private GameObject potionHolder;

    private void Start()
    {
        potionHolder = this.gameObject;
    }

    private void Update()
    {
        if (GameManagerLogic.Instance.getIsLevelOver())
        {
            destroyChildObjects();
        }
    }

    private void destroyChildObjects()
    {
        for (int i = 0; i < potionHolder.transform.childCount; i++)
        {
            Destroy(potionHolder.transform.GetChild(i).gameObject);
        }
    }
}
