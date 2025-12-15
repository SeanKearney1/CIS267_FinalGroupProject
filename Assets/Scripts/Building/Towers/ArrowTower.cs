using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : MonoBehaviour
{
    public GameObject arrowProjectile;
    public float rate;
    private double timeIncrement = 0;
    private RangeController rangeController;
    public GameObject towerHead;

    public AudioClip audio_shoot;
    private AudioSource audioSource;


    void Start()
    {
        rangeController = GetComponentInChildren<RangeController>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
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
            Vector3 targetPos = rangeController.enemyPosition();// get position
            Vector3 direction3 = targetPos - transform.position;// make psoition relative to tower
            // Convert to 2D
            Vector2 direction = new Vector2(direction3.x, direction3.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// convert to angle
            Instantiate(arrowProjectile, transform.position, Quaternion.Euler(0, 0, angle));// create with given angle
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
