using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_NextLevel : MonoBehaviour
{
    public TMP_Text headerTxt;

    private Button selectedBtn;
    private TMP_Text buttonText;
    private UI_NewGame newGameScript;
    private UI_button_sounds sounds;




    private void Start()
    {
        buttonText = gameObject.transform.GetComponentInChildren<TMP_Text>();
        selectedBtn = gameObject.GetComponent<Button>();
        newGameScript = GetComponent<UI_NewGame>();
        sounds = GetComponent<UI_button_sounds>();
        updateNextLevelGUI();
    }

    public void goToNextLevel()
    {
        if(!GameManagerLogic.Instance.getIsSceneButtonClicked() && !GameManagerLogic.Instance.getIsGameOver())
        {
            GameManagerLogic.Instance.setIsSceneButtonClicked(true);
            int sceneNum = GameManagerLogic.Instance.getCurrentSceneNumber();
            GetComponent<UI_Scene_Selector>().setLevelIndex(sceneNum);
            GetComponent<UI_Scene_Selector>().SelectLevel();
            //gets rid of the eventsystems selected object
            //in order to prevent the new button from being called more than once when clicked.
            //EventSystem.current.SetSelectedGameObject(null);
        }
    }

    private void updateNextLevelGUI()
    {
        selectedBtn.onClick.RemoveAllListeners();
        GameManagerLogic.Instance.addLevelWon();
        if (GameManagerLogic.Instance.getNumOfLevelsWon() >= 3)
        {
            GameManagerLogic.Instance.setIsGameWon(true);
            GameManagerLogic.Instance.setIsGameOver(true);
        }
        if (GameManagerLogic.Instance.getIsGameWon())
        {
            headerTxt.text = "You've survied and beat back the enemy hordes. \r\nClick the button below to play again";
            buttonText.text = "New Game";
            selectedBtn.onClick.AddListener(newGameScript.startNewGame);
            selectedBtn.onClick.AddListener(sounds.OnClick);
        }
        else if (GameManagerLogic.Instance.getIsLevelOver())
        {
            //GameManagerLogic.Instance.nextScene();
            headerTxt.text = "You've Completed the level. \r\nClick the button below to proceed to the next level";
            buttonText.text = "Next Level";
            selectedBtn.onClick.AddListener(goToNextLevel);
            selectedBtn.onClick.AddListener(sounds.OnClick);
        }
    }
}
