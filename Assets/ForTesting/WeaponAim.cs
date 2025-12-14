using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public GameObject sights;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 aimDirection = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        sights.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if(angle > 90 || angle < -90)
        {
            //player.localScale = new Vector3(-1, 1, 1);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            //player.localScale = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
