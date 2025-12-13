using UnityEngine;

public class OnEnablePause : MonoBehaviour
{
    private void OnEnable()
    {
        GameManagerLogic.Instance.pauseTime();
    }
    private void OnDisable()
    {
        GameManagerLogic.Instance.startTime();
    }
}
