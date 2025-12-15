using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public GameObject CannonballExplosion;
    public float rate;
    private double timeIncrement = 0;
    private RangeController rangeController;
    public GameObject towerHead;

    public AudioClip audio_shoot;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rangeController = GetComponentInChildren<RangeController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        aimHead();
        timeIncrement += Time.deltaTime;
        if (timeIncrement >= rate)
        {
            fire();

        }
    }
    private void fire()
    {
        if (rangeController.isAnEnemyInRange())
        {
            timeIncrement = 0;
            Vector3 targetPos = rangeController.enemyPosition();
            Instantiate(CannonballExplosion, targetPos, transform.rotation);// spawn the explosion right on top of the enemy
            audioSource.clip = audio_shoot;
            audioSource.Play();
        }
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
