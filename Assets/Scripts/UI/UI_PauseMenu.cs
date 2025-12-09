using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_PauseMenu : MonoBehaviour
{
    [Header("--Menu Header Text--")]
    public TMP_Text menuHeaderText;

    private void Update()
    {
        if(GameManagerLogic.Instance.getIsGameOver())
        {
            menuHeaderText.text = "Game Over";
        }
        else
        {
            menuHeaderText.text = "Game Paused";
        }    
    }
}
