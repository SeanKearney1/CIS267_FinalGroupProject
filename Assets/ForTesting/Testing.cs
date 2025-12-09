using UnityEngine;

public class Testing : MonoBehaviour
{

    public void gameOverBtnClick()
    {
        GameManagerLogic.Instance.setIsGameOver(true);
    }
}
