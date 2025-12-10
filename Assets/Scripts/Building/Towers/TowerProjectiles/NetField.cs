using UnityEngine;

public class NetField : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    public float lifespan;
    public float pullStrength;
    public int damage;
    



    void Start()
    {
        Destroy(this.gameObject, lifespan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            enemyRB = collision.gameObject.GetComponent<Rigidbody2D>();
            //====
            //====
            enemyController.applyStagger(1.5f);
            healthController.takeDamage(damage);
            enemyRB.linearVelocity = Vector3.zero;
        }
    }
}
