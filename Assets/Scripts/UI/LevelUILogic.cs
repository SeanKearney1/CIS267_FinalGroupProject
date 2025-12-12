using UnityEngine;

public class LevelUILogic : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject nextLevelUI;

    private void Update()
    {
        gameOverCheck();
        levelCompleteCheck();
    }

    private void gameOverCheck()
    {
        if(GameManagerLogic.Instance.getIsGameOver())
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void levelCompleteCheck()
    {
        if(GameManagerLogic.Instance.getIsLevelOver())
        {
            nextLevelUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else //<<might not need
        {
            nextLevelUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
