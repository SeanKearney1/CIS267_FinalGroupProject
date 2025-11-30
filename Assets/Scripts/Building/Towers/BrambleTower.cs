using UnityEngine;

public class BrambleTower : MonoBehaviour
{
    public GameObject scaledBramble;
    private HealthController healthController;
    private float scale=0;
    public int regenDelay;
    private float regenTime;
    public GameObject damageBubble;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthController = this.gameObject.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthScaling();
        setBrambleScale();
        grow();
    }
    private void setBrambleScale()
    {
        scaledBramble.transform.localScale = new Vector3(scale, scale, 1f);
    }
    private void HealthScaling()
    {
        float hp = healthController.getHealth();   // Expecting 0–100
        float t = Mathf.Clamp01(hp / 100f);
        scale = Mathf.Lerp(0.2f, 5f, t);// function y=\frac{24}{500}x+\frac{1}{5}// in desmos, scales from .2x at 0 to 5x at 100
    }
    private void grow()
    {
        if(regenDelay < regenTime)
        {
            healthController.rejuvinate(Mathf.RoundToInt(scale * 1f));
            regenTime = 0;
            GameObject spawnedBubble = Instantiate(damageBubble, transform.position,transform.rotation);
            spawnedBubble.transform.localScale = new Vector3(scale, scale , 1f);
        }
        else 
        {
            regenTime += Time.deltaTime;
        }
        
    }

}
