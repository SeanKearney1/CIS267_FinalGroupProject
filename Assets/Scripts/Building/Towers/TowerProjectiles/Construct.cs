using Unity.VisualScripting;
using UnityEngine;

public class Construct : MonoBehaviour
{
    private RangeController range;
    private Rigidbody2D rb;
    bool hasTarget = false;
    public GameObject homePlate;
    public int speed;
    public GameObject damagebubble;

    public float fireRate;
    private float ratetimeincrement;



    private void Start()
    {
        range = GetComponentInChildren<RangeController>();
        rb = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        hasTarget = range.isAnEnemyInRange();
        fire();
    }
    void FixedUpdate()
    {
        float moveSpeed = speed * Time.fixedDeltaTime;
        handleMovement(moveSpeed);
    }

    private void fire()
    {
        if (hasTarget) 
        {
            ratetimeincrement += Time.deltaTime;
            if (ratetimeincrement > fireRate) 
            {
                Instantiate(damagebubble, transform.position,transform.rotation);
                ratetimeincrement = 0;
            }
        }
    }
    private void handleMovement(float moveSpeed)
    {
        if (hasTarget)
        {
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, range.enemyPosition(), moveSpeed);//taken from enemycontroller
            rb.MovePosition(moveToPos);
        }
        else
        {
            Vector2 moveToPos = Vector2.MoveTowards(rb.position, homePlate.transform.position, moveSpeed);//taken from enemycontroller
            rb.MovePosition(moveToPos);
        }
    }
}
