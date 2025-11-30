using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

public class EnemyController : MonoBehaviour
{

    //Place this on an enemy prefab and set the city gate or default target
    //Be sure to add any waypoints to the list in the EnemySpawer
    //Enemy must also have an AggroController on their prefab



    [Header("--Enemy Data--")]
    public float speed;
    public float aggroRange;
    public int damage;

    private GameObject defaultTarget;
    private List<GameObject> waypointList = new List<GameObject>();
    private Rigidbody2D rb;
    private AggroController aggroCtrl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aggroCtrl = gameObject.transform.GetChild(0).GetComponent<AggroController>();
    }

    void FixedUpdate()
    {
        float moveSpeed = speed * Time.fixedDeltaTime;
        if(aggroCtrl.hasTargetInRange())
        {
            moveTowardsTarget(moveSpeed);
        }
        else
        {
            defaultMovement(moveSpeed);
        }
    }

    //Used to set the default movement target to either the waypoint if there is one
    //Or the city gate/default target
    private void defaultMovement(float mSpeed)
    {
        if(hasWaypoints())
        {
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, waypointList[0].transform.position, mSpeed);
            rb.MovePosition(moveToPos);
        }
        else if (defaultTarget != null)
        {
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, defaultTarget.transform.position, mSpeed);
            rb.MovePosition(moveToPos);
        }
    }
    //Used to move the enemy towards the first target in range.
    private void moveTowardsTarget(float mSpeed)
    {
        Vector2 moveToPos = Vector2.MoveTowards(rb.position, aggroCtrl.getTargetPosition(), mSpeed);
        rb.MovePosition(moveToPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //removes the waypoint once it comes into range
        if (collision.gameObject.CompareTag("Waypoint"))
        {
            waypointList.Remove(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            collision.gameObject.GetComponent<HealthController>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            //add damage to player here?
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("CityGate"))
        {
            //add damage to city gate here
            Destroy(gameObject);
        }
    }
    public void setDefaultTarget(GameObject gate)
    {
        defaultTarget = gate;
    }
    public void setPathWaypoints(List<GameObject> path)
    {
        waypointList.AddRange(path);
    }
    private bool hasWaypoints()
    {
        if(waypointList.Count > 0 )
        {
            return true;
        }
        return false;
    }

}
