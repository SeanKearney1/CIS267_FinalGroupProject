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
    private Animator animator;
    private bool isSwinging;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        wHandler = GetComponent<WeaponHandler>();
        isSwinging = false;

    }
    void Update()
    {
        playerMovement();
        playerAttack();
        rb.linearVelocity = moveVelocity;
        if (rb.linearVelocity != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private void FixedUpdate()
    {
        //rb.linearVelocity = moveVelocity;
        //if (rb.linearVelocity != Vector2.zero)
        //{
        //    animator.SetBool("isWalking", true);
        //}
        //else
        //{
        //    animator.SetBool("isWalking", false);
        //}
    }
    private void playerMovement()
    {
        //animator.SetBool("isWalking", true);
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");
        flipPlayerSprite(xPos);
        Vector2 pMove = new Vector2(xPos, yPos).normalized;
        moveVelocity = pMove * speed;
    }
    private void playerAttack()
    {
        if(Input.GetMouseButtonDown(0) && !isSwinging)
        {
            isSwinging = true;
            animator.SetTrigger("attack");

        }
        else if(Input.GetMouseButton(0) && !isSwinging)
        {
            isSwinging = true;
            animator.SetTrigger("attack");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerWeapon"))
        {
            wHandler.addWeaponToInventory(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("RepairHammer")) // should repair hammer be static or a reward??
        {
            GameManagerLogic.Instance.setHasRepairHammer(true);
            Destroy(collision.gameObject);
        }
    }
    private void flipPlayerSprite(float moveX)
    {
        if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveX > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    public void endOfSwingAnimation()
    {
        isSwinging = false;
    }
}
