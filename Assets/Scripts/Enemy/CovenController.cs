using UnityEngine;

public class CovenController : MonoBehaviour
{
    private AggroController AggroController;

    public GameObject arrowProjectile;
    public float rate;
    private double timeIncrement = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AggroController = GetComponentInChildren<AggroController>();
    }
    private void Update()
    {
        timeIncrement += Time.deltaTime;
        if (timeIncrement >= rate)
        {
            fire();
        }
    }
    private void fire()
    {
        if (AggroController.hasTargetInRange())
        {
            timeIncrement = 0;
            Vector3 targetPos = AggroController.getTargetPosition();// get position
            Vector3 direction3 = targetPos - transform.position;// make psoition relative to tower
            // Convert to 2D
            Vector2 direction = new Vector2(direction3.x, direction3.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// convert to angle
            Instantiate(arrowProjectile, transform.position, Quaternion.Euler(0, 0, angle));// create with given angle
        }
    }
}
