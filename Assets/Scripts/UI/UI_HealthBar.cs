using UnityEngine;

public class UI_HealthBar : MonoBehaviour
{
    private HealthController curObjHealthController;
    private Transform greenHealthBar;

    private void Start()
    {
        curObjHealthController = gameObject.GetComponentInParent<HealthController>();
        greenHealthBar = gameObject.transform.GetChild(0);
        greenHealthBar.localScale = new Vector3(1, 1, 1);
    }
    private void Update()
    {
        updateHealthBar();
    }

    private void updateHealthBar()
    {
        float curHealth = curObjHealthController.getHealth();
        int baseHealth = curObjHealthController.getBaseHealth();
        //Debug.Log("tempHealth: " + (curHealth / baseHealth) + " - curHealth: " + curHealth + " - baseHealth: " + baseHealth);
        greenHealthBar.localScale = new Vector3((curHealth / baseHealth), 1, 1);
    }

}
