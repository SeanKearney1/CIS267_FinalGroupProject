using UnityEngine;

public class UI_MenuSelector : MonoBehaviour
{
    [Header("--Menu Prefabs--")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject guideMenu;

    private void OnEnable()
    {
        openMainMenu();
        //Time.timeScale = 0f;
        GameManagerLogic.Instance.pauseTime();
        //GameManagerLogic.Instance.setIsGamePaused(true);
    }

    private void OnDisable()
    {
        //Time.timeScale = 1f;
        GameManagerLogic.Instance.startTime();
        //GameManagerLogic.Instance.setIsGamePaused(false);
    }

    public void openGuideMenu()
    {
        guideMenu.SetActive(true);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void openSettingsMenu()
    {
        guideMenu.SetActive(false);
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void openMainMenu()
    {
        guideMenu.SetActive(false);
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
