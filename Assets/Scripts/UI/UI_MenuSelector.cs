using UnityEngine;

public class UI_MenuSelector : MonoBehaviour
{
    [Header("--Menu Prefabs--")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject guideMenu;


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
