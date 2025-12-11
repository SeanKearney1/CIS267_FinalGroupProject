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
    }
    private void Update()
    {
        isGameOverCheck();
    }

    public void goToNextLevel()
    {
        List<int> tempSceneOrder = GameManagerLogic.Instance.getListOfSceneOrder();
        gameObject.GetComponent<UI_Scene_Selector>().setLevelIndex(tempSceneOrder[0]);
        gameObject.GetComponent<UI_Scene_Selector>().SelectLevel();
        tempSceneOrder.RemoveAt(0);
        GameManagerLogic.Instance.setListOfSceneOrder(tempSceneOrder);
    }

    private void isGameOverCheck()
    {
        if(GameManagerLogic.Instance.getIsGameWon())
        {
            headerTxt.text = "You've Completed the game. \r\nClick the button below to play again";
            buttonText.text = "New Game";
            newGameScript = GetComponent<UI_NewGame>();
            gameObject.GetComponent<Button>().onClick.AddListener(newGameScript.startNewGame);
        }
        else
        {
            headerTxt.text = "You've Completed the level. \r\nClick the button below to proceed to the next level";
            buttonText.text = "Next Level";
            gameObject.GetComponent<Button>().onClick.AddListener(goToNextLevel);
        }
    }

}
