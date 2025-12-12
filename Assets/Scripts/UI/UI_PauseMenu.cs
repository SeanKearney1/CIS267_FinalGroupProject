using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_PauseMenu : MonoBehaviour
{
    [Header("--Menu Objects--")]
    public TMP_Text menuHeaderText;

    public Button newOrResumeGameBtn;

    private void Update()
    {
        if(GameManagerLogic.Instance.getIsGameOver())
        {
            menuHeaderText.text = "Game Over";
            TMP_Text tempText = newOrResumeGameBtn.transform.GetComponentInChildren<TMP_Text>();
            tempText.text = "New Game";
        }
        else
        {
            menuHeaderText.text = "Game Paused";
            TMP_Text tempText = newOrResumeGameBtn.transform.GetComponentInChildren<TMP_Text>();
            tempText.text = "Resume Game";
        }    
    }
}
