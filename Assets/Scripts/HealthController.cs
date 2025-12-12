using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int baseHP;//set the base hp for the prefab, also functions as the upper limit
    private int curHP = 0;// the changing hp ammount 

    public int resistance;// falt number that damage is reduced by damage taken = dmg - resitance && > 0
    private bool vulnerable = false;// if true multiply dmg * 2 before resistance calculation && divide healing by 2
    private bool onFire = false;
    public int vitality = 1;// multiplier to ammount healed 

    private float tickRate = 1;
    private float tickIncrement = 0;

    private void Start()
    {
        curHP = baseHP;
    }
    private void FixedUpdate()
    {
        if (onFire)
        {
            tickIncrement += Time.deltaTime;
            if (tickIncrement > tickRate)
            {
                takeDamage(1);
                tickIncrement = 0;
            }
        }
    }
    public void takeDamage(int dmg)
    {
        if (vulnerable)// apply vulnerability
        {
            dmg = Mathf.RoundToInt(dmg * 2);
        }
        dmg -= resistance;// apply resistance
        if (dmg < 0)// dmg cannot be less than 0
        {
            dmg = 0;
        }
        curHP -= dmg;//take damage
        if (curHP <= 0)// die
        {
            //used to make sure the object being destroyed is the enemy
            //before triggering the item drop
            if (gameObject.tag == "enemy")
            {
                //Debug.Log("H: " + gameObject.tag);
                gameObject.GetComponent<DropOnDeath>().randomizeDrop();
            }
            Destroy(this.gameObject);
        }
    }
    public void rejuvinate(int heal)
    {
        heal = heal * vitality;// add vitality
        if (vulnerable)// add vulnarbility
        {
            heal = heal / 2;
        }
        curHP += heal;
        if (curHP > baseHP)
        {
            curHP = baseHP;
        }
    }
    public void applyVulnerable()
    {
        vulnerable = true;
    }
    public void lightOnFire()
    {
        onFire = true;
    }
    public int getHealth()
    {
        return curHP;
    }
    public int getBaseHealth()
    {
        return baseHP;
    }
}
