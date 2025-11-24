using UnityEngine;

public class ClubSmack : MonoBehaviour
{
    public float lifetime;
    bool hitTriggered=false;
    public int damage;

    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            if (!hitTriggered)
            {
                healthController.takeDamage(damage);
                hitTriggered = true;
            }
        }
    }
}
