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
        if(GameManagerLogic.Instance.getIsGameOver() && !GameManagerLogic.Instance.getIsGameWon())
        {
            if(!PauseMenu.activeSelf)
            {
                showPauseMenu();
                //Invoke(nameof(showPauseMenu), .5f);
            }
            //Time.timeScale = 0f;
            //GameManagerLogic.Instance.pauseTime();
        }

    }

    private void levelCompleteCheck()
    {
        if(GameManagerLogic.Instance.getIsLevelOver())
        {
            nextLevelUI.SetActive(true);
            //Time.timeScale = 0f;
            //GameManagerLogic.Instance.pauseTime();
        }
        else //<<might not need
        {
            nextLevelUI.SetActive(false);
            //Time.timeScale = 1f;
            //GameManagerLogic.Instance.startTime();
        }
    }
    private void showPauseMenu()
    {
        PauseMenu.SetActive(true);
    }

}
