using TMPro;
using UnityEngine;

public class UpdatePotionCount : MonoBehaviour
{
    private TMP_Text potCountTxt;

    private void Start()
    {
        potCountTxt = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        updatePotionCount();
    }

    private void updatePotionCount()
    {
        potCountTxt.text = GameManagerLogic.Instance.getHealthPotCount().ToString();
    }
}
