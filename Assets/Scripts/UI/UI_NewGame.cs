using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UI_NewGame : MonoBehaviour
{

    public void startNewGame()
    {

        int sceneNum = GameManagerLogic.Instance.updateSceneList();
        GetComponent<UI_Scene_Selector>().setLevelIndex(sceneNum);
        GetComponent<UI_Scene_Selector>().SelectLevel();
    }

    ////create the list of scenes in order from 1 to 3 
    //private List<int> setTempSceneList(int cnt)
    //{
    //    List<int> tempList = new List<int>();
    //    for (int i = 1; i < cnt; i++)
    //    {
    //        tempList.Add(i);
    //    }
    //    return tempList;
    //}
    ////shuffle the list of scenes randomizing their order
    //private List<int> shuffleSceneOrder(List<int> originalList)
    //{
    //    List<int> tempList = new List<int>();
    //    List<int> randomList = new List<int>();
    //    tempList.AddRange(originalList);

    //    for(int i = 0; i < originalList.Count; i++)
    //    {
    //        int ran = Random.Range(0, tempList.Count);
    //        randomList.Add(tempList[ran]);
    //        tempList.RemoveAt(ran);
    //    }
    //    return randomList;
    //}

}
