using TMPro;
using UnityEngine;

public class updateUItoMatchGold : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text goldtext;

    private int curInt;
    private int gotVal;


    private void FixedUpdate()
    {
       gotVal = EconManager.GiveGold();
        if (gotVal != curInt)
        {
            goldtext.text = gotVal.ToString();
            curInt = gotVal;
        }
    }
}
