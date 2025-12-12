using UnityEngine;

public class OnGateDestroyed : MonoBehaviour
{
    private void Start()
    {
        GameManagerLogic.Instance.setIsGameOver(false);
    }
    private void OnDestroy()
    {
        Debug.Log("gate Destroyed");
        GameManagerLogic.Instance.setIsGameOver(true);
    }

    private void gateHealthCheck()
    {
        if(gameObject.GetComponent<HealthController>().getHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
