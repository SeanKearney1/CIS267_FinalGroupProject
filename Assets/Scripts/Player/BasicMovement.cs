using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    //==PUBLIC==// 
    [Header("--Player Speed--")]
    public float speed;

    //==PRIVATE==//
    private Rigidbody2D rb;
    private WeaponHandler wHandler;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wHandler = GetComponent<WeaponHandler>();
    }
    void Update()
    {
        PlayerMovement();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = moveVelocity;
    }
    private void PlayerMovement()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        Vector2 pMove = new Vector2(xPos, yPos).normalized;
        moveVelocity = pMove * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerWeapon")
        {
            wHandler.addWeaponToInventory(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.transform.tag == "RepairHammer") // should repair hammer be static or a reward??
        {
            GameManagerLogic.Instance.setHasRepairHammer(true);
            Destroy(collision.gameObject);
        }
    }
}
