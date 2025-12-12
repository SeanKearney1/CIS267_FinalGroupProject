using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UI_NextLevel : MonoBehaviour
{
    public TMP_Text headerTxt;

    private TMP_Text buttonText;
    private UI_NewGame newGameScript;




    private void Start()
    {
        buttonText = gameObject.transform.GetComponentInChildren<TMP_Text>();
        updateNextLevelGUI();
    }

    public void goToNextLevel()
    {
        int sceneNum = GameManagerLogic.Instance.updateSceneList();
        GetComponent<UI_Scene_Selector>().setLevelIndex(sceneNum);
        GetComponent<UI_Scene_Selector>().SelectLevel();

    }

    private void updateNextLevelGUI()
    {
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        GameManagerLogic.Instance.addLevelWon();
        if (GameManagerLogic.Instance.getNumOfLevelsWon() >= 3)
        {
            GameManagerLogic.Instance.setIsGameWon(true);
        }
        if(GameManagerLogic.Instance.getIsGameWon())
        {
            headerTxt.text = "You've survied and beat back the enemy hordes. \r\nClick the button below to play again";
            buttonText.text = "New Game";
            newGameScript = GetComponent<UI_NewGame>();
            gameObject.GetComponent<Button>().onClick.AddListener(newGameScript.startNewGame);
        }
        else if(GameManagerLogic.Instance.getIsLevelOver())
        {
            headerTxt.text = "You've Completed the level. \r\nClick the button below to proceed to the next level";
            buttonText.text = "Next Level";
            gameObject.GetComponent<Button>().onClick.AddListener(goToNextLevel);
        }
    }

}
