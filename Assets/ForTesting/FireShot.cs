using UnityEngine;

public class FireShot : MonoBehaviour
{

    [Header("--Magic Shot Data--")]
    public int damage;
    public float speed;
    public float lifeSpan;

    private void Start()
    {
        Invoke("destroyShot", lifeSpan);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public int getShotDamage()
    {
        return damage;
    }
    public void setBulletDamage(int dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("PlayerWeapon"))
        {
            if(collision.gameObject.CompareTag("enemy"))
            {
                collision.gameObject.GetComponent<HealthController>().takeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("PlayerWeapon"))
        {
            Destroy(this.gameObject);
        }
    }
}
