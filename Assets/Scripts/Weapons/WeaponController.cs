using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private WeaponObject curWeapon;
    private bool isHammer;

    public void setCurWeaponObj(WeaponObject obj)
    {
        curWeapon = obj;
        setIsHammer();
    }
    private void setIsHammer()
    {
        if (curWeapon.weaponType == "Repair")
        {
            // if curWeapon == repair hammer
            isHammer = true;
        }
        else
        {
            isHammer = false;
        }
    }

    private bool isPlayerAttacking()
    {
        if(Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else if(Input.GetMouseButton(0))
        {
            return true;
        }
        return false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isHammer && isPlayerAttacking()) 
        {
            if(collision.gameObject.CompareTag("Tower"))
            {
                // repair hammer's damage = its repair amount
                Debug.Log("repairing: " + curWeapon.weaponDmg);
                collision.gameObject.GetComponent<HealthController>().rejuvinate(curWeapon.weaponDmg);
            }
        }
        else if(isPlayerAttacking())
        {
            if(collision.gameObject.CompareTag("enemy"))
            {
                collision.gameObject.GetComponent<HealthController>().takeDamage(curWeapon.weaponDmg);
            }
        }
    }
}
