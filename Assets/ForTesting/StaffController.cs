using Unity.VisualScripting;
using UnityEngine;

public class StaffController : MonoBehaviour
{

    [Header("--References--")]
    public GameObject magicShot;
    public GameObject muzzle;
    public float fireRate;


    private float shotDelay;
    private bool canShoot;

    WeaponObject weaponData;

    public void initializeStaff(WeaponObject wObj)
    {
        weaponData = wObj;
    }


    void Start()
    {
        canShoot = true;

        FireShot bulletData = magicShot.gameObject.GetComponent<FireShot>();
        if (bulletData != null)
        {
            bulletData.setBulletDamage(magicShot.gameObject.GetComponent<FireShot>().getShotDamage());
        }
    }

    private void Update()
    {
        if (shotDelay <= 0)
        {
            canShoot = true;
            shotDelay = fireRate;
        }
        else
        {
            shotDelay -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot)
            {
                canShoot = false;
                shootMagicShot();
            }
        }
    }

    private void shootMagicShot()
    {
        Instantiate(magicShot, muzzle.transform.position, transform.rotation);
    }
}
