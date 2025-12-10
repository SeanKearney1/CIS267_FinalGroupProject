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
        randomSceneOrder = shuffleSceneOrder(sceneCnt);
    }

    private List<int> setTempSceneList(int cnt)
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < cnt; i++)
        {
            tempList.Add(i);
        }
        return tempList;
    }

    private List<int> shuffleSceneOrder(int cnt)
    {
        List<int> tempList = new List<int>();
        List<int> randomList = new List<int>();
        tempList.AddRange(setTempSceneList(cnt));

        for(int i = 0; i < cnt; i++)
        {
            int ran = Random.Range(0, tempList.Count);
            Debug.Log("ran: " +  ran);
            randomList.Add(tempList[ran]);
            tempList.RemoveAt(ran);
        }
        return randomList;
    }

}
