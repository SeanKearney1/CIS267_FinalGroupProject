using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UI_NewGame : MonoBehaviour
{
    private List<int> randomSceneOrder;

    public void startNewGame()
    {
        int sceneCnt = SceneManager.sceneCountInBuildSettings;
        Debug.Log("count: " + sceneCnt);
        randomSceneOrder = shuffleSceneOrder(setTempSceneList(sceneCnt));
        GetComponent<UI_Scene_Selector>().setLevelIndex(randomSceneOrder[0]);
        GetComponent<UI_Scene_Selector>().SelectLevel();
        randomSceneOrder.RemoveAt(0);
        GameManagerLogic.Instance.setListOfSceneOrder(randomSceneOrder);
        for(int i = 0; i < randomSceneOrder.Count; i++)
        {
            Debug.Log("order: " + randomSceneOrder[i]);
        }
    }

    //create the list of scenes in order from 1 to 3 
    private List<int> setTempSceneList(int cnt)
    {
        List<int> tempList = new List<int>();
        for (int i = 1; i < cnt; i++)
        {
            tempList.Add(i);
        }
        return tempList;
    }
    //shuffle the list of scenes randomizing their order
    private List<int> shuffleSceneOrder(List<int> originalList)
    {
        List<int> tempList = new List<int>();
        List<int> randomList = new List<int>();
        tempList.AddRange(originalList);

        for(int i = 0; i < originalList.Count; i++)
        {
            int ran = Random.Range(0, tempList.Count);
            randomList.Add(tempList[ran]);
            tempList.RemoveAt(ran);
        }
        return randomList;
    }

}
