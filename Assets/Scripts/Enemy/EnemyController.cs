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
    public int damage;

    private GameObject defaultTarget;
    private List<GameObject> waypointList = new List<GameObject>();
    private Rigidbody2D rb;
    private AggroController aggroCtrl;

    private float staggeredTime=0;
    private bool isStaggered = false;

    public int aggroType;
    // 1 = lemming ignore targets
    // 2 = default approach all things in range// nothing actually checks if 2 yet its basically the default logic
    // 3 = siege approach and use ranged attack // currently unused

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //aggroCtrl = gameObject.transform.GetChild(0).GetComponent<AggroController>();
        aggroCtrl = gameObject.GetComponentInChildren<AggroController>();
    }

    void FixedUpdate()
    {
        StaggerCD();
        if (!isStaggered)
        {
            if (aggroCtrl.hasTargetInRange() && aggroType != 1)//has target and is not lemming
            {
                moveTowardsTarget(speed);
            }
            else
            {
                defaultMovement(speed);
            }
        }
    }

    //Used to set the default movement target to either the waypoint if there is one
    //Or the city gate/default target
    private void defaultMovement(float mSpeed)
    {
        if (hasWaypoints())
        {
            Vector2 targetPos = waypointList[0].transform.position;
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime);
            rb.MovePosition(moveToPos);
        }
        else if (defaultTarget != null)
        {
            Vector2 targetPos = defaultTarget.transform.position;
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime);
            rb.MovePosition(moveToPos);
        }
    }
    //Used to move the enemy towards the first target in range.
    private void moveTowardsTarget(float mSpeed)
    {
        if(aggroType != 3)// if ranged use ranged attacks
        {
            Vector2 targetPos = aggroCtrl.getTargetPosition();
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, targetPos, mSpeed * Time.fixedDeltaTime);
            rb.MovePosition(moveToPos);
        }
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
            applyStagger(0.5f);
            // enemeis bounce off of thier targer instead of dieing
            rb.linearVelocity = Vector2.zero;
            Vector2 direction = (this.transform.position - collision.transform.position).normalized;
            direction *= 2;
            rb.AddForce(direction, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            //add damage to player here?
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("CityGate"))
        {
            //add damage to city gate here

            //this needs to be done better. Just startNewGame for now.
            collision.gameObject.GetComponent<HealthController>().takeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("HitBox"))
        {
            //damage to the enemy health
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
    public void applyStagger(float time)
    {
        staggeredTime = time;
        isStaggered = true;
    }
    private void StaggerCD()
    {
        if (isStaggered)
        {
            staggeredTime -= Time.deltaTime;
            if (staggeredTime < 0 )
            {
                staggeredTime = 0;
                isStaggered=false;
            }
        }
    }

}
