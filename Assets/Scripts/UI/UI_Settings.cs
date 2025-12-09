using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    [Header("--UI Slider--")]
    public Slider mainVolumeSlider;
    [Header("--UI Textboxes--")]
    public TMP_Text mainVolumeTxt;


    private void Update()
    {
        updatedSlideTxt();
    }

    private void updatedSlideTxt()
    {
        mainVolumeTxt.text = ((int)mainVolumeSlider.value).ToString();
    }
}
