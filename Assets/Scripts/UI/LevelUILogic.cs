using UnityEngine;

public class LevelUILogic : MonoBehaviour
{
    public GameObject PauseMenu;

    private void Update()
    {
        gameOverCheck();
    }

    private void gameOverCheck()
    {
        if(GameManagerLogic.Instance.getIsGameOver())
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
