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
    private bool isFirstWave;


    void Start()
    {
        isFirstWave = true;
        WaveManager.wmInstance.setWaveTimerScript(this);
        nextWavePanel.SetActive(false);
        waveCompletePanel.SetActive(false);
        resetCountdown();
    }

    void Update()
    {
        if (!WaveManager.wmInstance.getIsSpawningWave())
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                tempWaveCntdown--;
                tempCompleteCntdown++;
                time = 0f;
            }
            nextWaveCntdownCheck();
            waveCompleteCntdownCheck();

        }
        else
        {
            nextWavePanel.SetActive(false);
            waveCompletePanel.SetActive(false);
            resetCountdown();
        }
    }
    // checking if timer for the wave complete panel is done or not
    private void waveCompleteCntdownCheck()
    {
        if (tempCompleteCntdown <= waveCompleteCntDown && !isFirstWave)
        {
            waveCompletePanel.SetActive(true);
        }
        else
        {
            waveCompletePanel.SetActive(false);
        }
    }
    // checking if timer for next wave panel is complete or not
    private void nextWaveCntdownCheck()
    {
        if (tempWaveCntdown >= 0)
        {
            nextWavePanel.SetActive(true);
            waveCntdownTxt.text = tempWaveCntdown.ToString();
        }
        else
        {
            //resetCountdown();
            waveCntdownTxt.text = tempWaveCntdown.ToString();
            nextWavePanel.SetActive(false);
            isFirstWave = false;
            WaveManager.wmInstance.startWave();
        }
    }

    private void resetCountdown()
    {
        //isCounting = false;
        tempWaveCntdown = nextWaveCntdown;
        tempCompleteCntdown = 0;
        time = 0f;
    }

    public void setIsCounting(bool isC)
    {
        isCounting = isC;
    }
}
