using UnityEngine;

public class HexProjectile : MonoBehaviour
{
    public int damage;
    public float lifespan;
    private bool hasHit = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, lifespan);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !hasHit)
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.takeDamage(damage);
            healthController.applyVulnerable();
            hasHit = true;
        }
    }
}
