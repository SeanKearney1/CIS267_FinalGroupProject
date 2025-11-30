using UnityEngine;
using System.Collections.Generic;

public class AggroController : MonoBehaviour
{
    //Basically the same as RangeController but set up to 
    //aggro onto towers and the player.
    //Place this on any enemy prefabs along with the EnemyController.


    [Header("--Aggro Range--")]
    public float aggroRange;

    private List<GameObject> targetList = new List<GameObject>();
    private CircleCollider2D rangeCollider;

    private void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        rangeCollider.radius = aggroRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            targetList.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tower") || collision.gameObject.CompareTag("Player"))
        {
            targetList.Remove(collision.gameObject);
        }
    }
    public bool hasTargetInRange()
    {
        if (targetList.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Vector2 getTargetPosition()
    {
        return targetList[0].transform.position;
    }

}
