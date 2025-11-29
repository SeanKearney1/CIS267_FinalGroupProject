using UnityEngine;

public class NetField : MonoBehaviour
{
    public int damage;
    private Rigidbody2D enemyRB;
    public float lifespan;
    public float pullStrength;


    void Start()
    {
        Destroy(this.gameObject, lifespan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.takeDamage(damage);
            // ENEMY MOVEMENT NEEDS TO BE CREATED BEFORE THIS CAN WORK
            //Vector2 pullDirection = (transform.position - collision.transform.position).normalized;
            //Rigidbody2D enemyRB = collision.GetComponent<Rigidbody2D>();
            //enemyRB.AddForce(pullDirection * pullStrength, ForceMode2D.Impulse);
        }
    }
}
