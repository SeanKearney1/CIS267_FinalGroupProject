using UnityEngine;

public class AlchemyOnDestroy : MonoBehaviour
{
    public GameObject alchemyPool;
    private void OnDestroy()
    {
        Instantiate(alchemyPool, transform.position, transform.rotation);
    }
}
