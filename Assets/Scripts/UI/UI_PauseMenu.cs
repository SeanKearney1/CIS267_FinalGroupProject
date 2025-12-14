using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : MonoBehaviour
{
    [Header("--Menu Objects--")]
    public TMP_Text menuHeaderText;

    public Button newOrResumeGameBtn;


    private UI_NewGame newGame;
    private UI_Resume resumeGame;
    private UI_button_sounds sounds;

    private void Start()
    {
        newGame = GetComponent<UI_NewGame>();
        resumeGame = GetComponent<UI_Resume>();
        sounds = GetComponent<UI_button_sounds>();
    }
    private void OnEnable()
    {
        gameOverCheck();
        
    }
    private void Update()
    {
    }

    private void gameOverCheck()
    {
        if (!GameManagerLogic.Instance.getIsGameWon())
        {
            if (GameManagerLogic.Instance.getIsGameOver())
            {
                menuHeaderText.text = "Game Over";
                TMP_Text tempText = newOrResumeGameBtn.transform.GetComponentInChildren<TMP_Text>();
                tempText.text = "New Game";
                newOrResumeGameBtn.onClick.RemoveAllListeners();
                newOrResumeGameBtn.onClick.AddListener(newGame.startNewGame);
                newOrResumeGameBtn.onClick.AddListener(sounds.OnClick);
            }
            else
            {
                menuHeaderText.text = "Game Paused";
                TMP_Text tempText = newOrResumeGameBtn.transform.GetComponentInChildren<TMP_Text>();
                tempText.text = "Resume Game";
                newOrResumeGameBtn.onClick.RemoveAllListeners();
                newOrResumeGameBtn.onClick.AddListener(resumeGame.Resume);
                newOrResumeGameBtn.onClick.AddListener(sounds.OnClick);
            }
        }
    }
}
