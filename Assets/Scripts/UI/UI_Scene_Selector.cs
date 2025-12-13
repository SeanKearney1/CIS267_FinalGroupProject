using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Scene_Selector : MonoBehaviour
{
    // Scene 0 is Main Menu.
    //Levels scene indexes go from 1 to 3.
    // If not check "Build Profiles" > Scene List to confirm.
    public int LevelIndex;

    public void SelectLevel()
    {
        SceneManager.LoadScene(LevelIndex);
        //needed to unpause the game on scene change
        //Time.timeScale = 1.0f; 
        GameManagerLogic.Instance.startTime();
    }

    //used with new game/next level to set the level index
    public void setLevelIndex(int lvl)
    {
        LevelIndex = lvl;
    }
}
