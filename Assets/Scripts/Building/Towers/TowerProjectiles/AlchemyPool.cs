using Unity.VisualScripting;
using UnityEngine;

public class AlchemyPool : MonoBehaviour
{
    public float rate;
    private float timeIncrement;
    public float lifetime;
    public int damage;

    public GameObject damageBubble;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }
    private void FixedUpdate()
    {
        timeIncrement += Time.deltaTime;
        if (timeIncrement > rate) 
        {
            Instantiate(damageBubble, transform.position, transform.rotation);
            timeIncrement = 0;
            Debug.Log("spawn");
        }
    }
    
    
}
