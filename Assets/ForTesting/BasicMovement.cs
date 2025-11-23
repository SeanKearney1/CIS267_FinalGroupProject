using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private WeaponHandler wHandler;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2f;
        wHandler = GetComponent<WeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }


    private void PlayerMovement()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        Vector2 pMove = new Vector2(xPos, yPos).normalized;
        rb.linearVelocity = pMove * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerWeapon")
        {
            wHandler.addWeaponToInventory(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}
