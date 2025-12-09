using UnityEngine;

public class OnGateDestroyed : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManagerLogic.Instance.setIsGameOver(true);
    }
}
