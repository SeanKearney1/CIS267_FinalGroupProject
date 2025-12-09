using UnityEngine;

public class UsePotion : MonoBehaviour
{
    public WeaponObject healthPotData;

    private HealthController playerHController;
    private WeaponHandler wHandler;

    private void Start()
    {
        playerHController = GetComponent<HealthController>();
        wHandler = GetComponent<WeaponHandler>();
    }
    private void Update()
    {
        potionKeyBindings();
    }

    private void potionKeyBindings()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            healthPotionResetCheck();
            updatedHealthPotionCnt();
        }
    }

    private void updatedHealthPotionCnt()
    {
        if (GameManagerLogic.Instance.getHealthPotCount() > 0)
        {
            GameManagerLogic.Instance.subHealthPotion();
            playerHController.rejuvinate(healthPotData.weaponDmg);
        }
    }
    private void healthPotionResetCheck()
    {
        if (GameManagerLogic.Instance.getHealthPotCount() == 1)
        {
            UI_Hotbar.hbInstance.setOutOfHealthPots();
            wHandler.setHealthPotObj(null);
        }
    }
}
