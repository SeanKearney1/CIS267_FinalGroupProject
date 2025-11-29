using UnityEngine;

public class Rage : MonoBehaviour
{
    private int multiplier;
    private HealthController healthController;
    public GameObject ragePulse;
    public int baseCD;
    private float CDtimescale=0;
    private RangeController rangeController;
    public GameObject towerHead;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthController = this.gameObject.GetComponent<HealthController>();
        rangeController = GetComponentInChildren<RangeController>();
        healthController.takeDamage(45);
    }

    // Update is called once per frame
    void Update()
    {
        setMult();
        Fire();
        aimHead();
    }
    private void Fire()
    {
        CDtimescale += Time.deltaTime * multiplier;
        if (CDtimescale >= baseCD)
        {
            CDtimescale = 0;
            Instantiate(ragePulse, transform.position,transform.rotation);
            healthController.rejuvinate(1);
        }
    }
    private void setMult()
    {
        int curHp = healthController.getHealth();
        multiplier = Mathf.RoundToInt(curHp * -0.1f) + 6;// 5x at 10, 4x at 20, 3x at 30.....
    }
    private void aimHead()
    {
        if (rangeController.isAnEnemyInRange())
        {
            Vector3 targetPos = rangeController.enemyPosition();// get position
            Vector3 direction3 = targetPos - transform.position;// make psoition relative to tower
            // Convert to 2D
            Vector2 direction = new Vector2(direction3.x, direction3.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// convert to angle
            towerHead.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
