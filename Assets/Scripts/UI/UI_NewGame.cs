using UnityEngine;
using UnityEngine.EventSystems;

public class UI_NewGame : MonoBehaviour
{

    public void startNewGame()
    {
        if(!GameManagerLogic.Instance.getIsSceneButtonClicked())
        {
            //GameManagerLogic.Instance.resetSceneCounter();
            GameManagerLogic.Instance.setIsSceneButtonClicked(true);
            GameManagerLogic.Instance.resetGameData();
            GameManagerLogic.Instance.shuffleSceneOrder();
            //GameManagerLogic.Instance.nextScene();
            int sceneNum = GameManagerLogic.Instance.getCurrentSceneNumber();
            GetComponent<UI_Scene_Selector>().setLevelIndex(sceneNum);
            GetComponent<UI_Scene_Selector>().SelectLevel();
            //gets rid of the eventsystems selected object
            //in order to prevent the new button from being called more than once when clicked.
            //EventSystem.current.SetSelectedGameObject(null);
        }
    }
}
