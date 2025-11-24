using UnityEngine;

public class DamageBubble : MonoBehaviour
{
    public int damage;
    private void Start()
    {
        Destroy(this.gameObject, 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.takeDamage(damage);
            Debug.Log("tick");
        }
    }
}
