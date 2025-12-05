using TMPro;
using UnityEngine;

public class UI_WaveTimer : MonoBehaviour
{
    //==PUBLIC==//
    [Header("--Next Wave Countdown--")]
    public int nextWaveCntdown;
    public int waveCompleteCntDown;
    public GameObject nextWavePanel;
    public GameObject waveCompletePanel;
    public TMP_Text waveCntdownTxt;

    //==PRIVATE==//
    private float time;
    private int tempWaveCntdown;
    private int tempCompleteCntdown;
    private bool isCounting;


    void Start()
    {
        nextWavePanel.SetActive(false);
        waveCompletePanel.SetActive(false);
        resetCountdown();
    }

    void Update()
    {
        if(isCounting)
        {
            time += Time.deltaTime;
            if(time >= 1f)
            {
                tempWaveCntdown--;
                tempCompleteCntdown++;
                time = 0f;
            }
            waveCompleteCntdownCheck();
            nextWaveCntdownCheck();
        }
    }
    private void waveCompleteCntdownCheck()
    {
        if(tempCompleteCntdown <= waveCompleteCntDown)
        {
            waveCompletePanel.SetActive(true);
        }
        else
        {
            waveCompletePanel.SetActive(false);
        }
    }
    private void nextWaveCntdownCheck()
    {
        if (tempWaveCntdown >= 0)
        {
            nextWavePanel.SetActive(true);
            waveCntdownTxt.text = tempWaveCntdown.ToString();
        }
        else
        {
            resetCountdown();
            waveCntdownTxt.text = tempWaveCntdown.ToString();
            nextWavePanel.SetActive(false);
        }
    }


    private void resetCountdown()
    {
        isCounting = false;
        tempWaveCntdown = nextWaveCntdown;
        tempCompleteCntdown = 0;
        time = 0f;
    }

    public void testingWaveOver()
    {
        isCounting = true;
    }

}
