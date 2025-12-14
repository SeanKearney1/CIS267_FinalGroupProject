using UnityEngine;

public class Testing : MonoBehaviour
{

    public void gameOverBtnClick()
    {
        GameManagerLogic.Instance.setIsGameOver(true);
    }

    public void testing()
    {
        WaveManager.wmInstance.waveSkip();
        //GameManagerLogic.Instance.setIsGameWon(true);
    }
}
