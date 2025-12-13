using UnityEngine;

public class UI_Resume : MonoBehaviour
{
    // Resume Game.
    public void Resume()
    {
        gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        //Time.timeScale = 1.0f;
        GameManagerLogic.Instance.startTime();
    }
}
