using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSettingManager : MonoBehaviour
{
    private AudioSource audioSource;

    public Slider volumSlider;
    public Toggle muteToggle;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = DataManager.Instance.CurrentVolum;
        audioSource.mute = DataManager.Instance.MuteState;

        volumSlider.value = DataManager.Instance.CurrentVolum;
        muteToggle.isOn = DataManager.Instance.MuteState;
    }

    private void Update()
    {
        DataManager.Instance.CurrentVolum = volumSlider.value;
        DataManager.Instance.MuteState = muteToggle.isOn;

        audioSource.volume = volumSlider.value;
        audioSource.mute = muteToggle.isOn;
    }
}
