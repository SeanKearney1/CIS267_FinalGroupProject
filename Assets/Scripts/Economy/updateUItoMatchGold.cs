using TMPro;
using UnityEngine;

public class updateUItoMatchGold : MonoBehaviour
{
    public TMP_Text goldtext;

    private int curInt;
    private int gotVal;

    //==FixedUpdate() wouldn't work with the PauseMenu_UI displaying the current gold==//
    //==So I replaced it with the normal Update() which shouldn't cause any issues ==//
    //==If so then feel free to change it back and I can just make a different script==//
    private void Update()
    {
        gotVal = EconManager.GiveGold();
        if (gotVal != curInt)
        {
            goldtext.text = gotVal.ToString();
            curInt = gotVal;
        }
    }
}
