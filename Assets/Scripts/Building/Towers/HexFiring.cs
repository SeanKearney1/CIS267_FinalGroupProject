using UnityEngine;

public class HexFiring : MonoBehaviour
{
    public GameObject CannonballExplosion;
    public float rate;
    private double timeIncrement = 0;
    private RangeController rangeController;

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
            Vector3 targetPos = rangeController.randEnemyPosition();
            Instantiate(CannonballExplosion, targetPos, transform.rotation);// spawn the explosion right on top of the enemy
            audioSource.clip = audio_shoot;
            audioSource.Play();
        }
    }
}
