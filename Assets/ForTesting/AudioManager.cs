using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections;
using System;

public class AudioManager : MonoBehaviour
{
    [Header("--Volume Slider--")]
    public Slider mainVolumeSlider;

    private List<AudioSource> listOfAllAudioSources = new List<AudioSource>();
    private AudioSource[] audioSourceList;

    //private void Start()
    //{
    //    audioSourceList = FindAllObjectsOfType<AudioSource>();
    //}


    //private void updateAudioSourceList()
    //{
    //    listOfAllAudioSources.Clear();
    //    listOfAllAudioSources = FindAnyObjectByType<AudioSource>();
    //}


}

