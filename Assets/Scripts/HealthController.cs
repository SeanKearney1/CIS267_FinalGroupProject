using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int baseHP;//set the base hp for the prefab, also functions as the upper limit
    private int curHP = 0;// the changing hp ammount

    public int resistance;// falt number that damage is reduced by damage taken = dmg - resitance && > 0
    private bool vulnerable = false;// if true multiply dmg * 1.5 before resistance calculation && divide healing by 2

    public int vitality = 1;// multiplier to ammount healed 

    private void Start()
    {
        curHP = baseHP;
    }
    public void takeDamage(int dmg)
    {
        if (vulnerable)// apply vulnerability
        {
            dmg = Mathf.RoundToInt(dmg * 1.5f);
        }
        dmg -= resistance;// apply resistance
        if (dmg < 0)// dmg cannot be less than 0
        {
            dmg = 0;
        }
        curHP -= dmg;//take damage
        if (curHP <= 0)// die
        {
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
}
