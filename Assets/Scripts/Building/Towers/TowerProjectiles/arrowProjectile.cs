using UnityEngine;

public class arrowProjectile : MonoBehaviour
{
    public float speed;
    public int damage;
    private Rigidbody2D rb;
    public float lifespan;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
        Destroy(this.gameObject, lifespan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
