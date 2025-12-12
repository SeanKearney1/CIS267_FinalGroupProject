using UnityEngine;

public class Testing : MonoBehaviour
{

    public void gameOverBtnClick()
    {
        GameManagerLogic.Instance.setIsGameOver(true);
    }

    public void testing()
    {
        WaveManager.wmInstance.testing();
        //GameManagerLogic.Instance.setIsGameWon(true);
    }
}
