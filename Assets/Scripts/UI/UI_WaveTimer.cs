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

    [Header("--Audio Clips--")]
    public AudioClip audio_countdown;
    public AudioClip audio_countdown_final;
    //==PRIVATE==//
    private float time;
    private int tempWaveCntdown;
    private int tempCompleteCntdown;
    private bool isCounting;
    private bool isFirstWave;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isFirstWave = true;
        WaveManager.wmInstance.setWaveTimerScript(this);
        nextWavePanel.SetActive(false);
        waveCompletePanel.SetActive(false);
        resetCountdown();
        audioSource.clip = audio_countdown;
        audioSource.Play();
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
                if (tempWaveCntdown >= 0)
                {
                    audioSource.clip = audio_countdown;
                    audioSource.Play();
                }
                else
                {
                    audioSource.clip = audio_countdown_final;
                    audioSource.Play();
                }
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
