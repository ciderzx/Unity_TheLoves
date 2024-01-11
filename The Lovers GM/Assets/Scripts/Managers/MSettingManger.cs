using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSettingManger : MonoBehaviour
{
    public GameObject stageUI;
    public GameObject settingUI;

    public Button settingButton;
    public Button stageButton;

    private AudioSource audioSource;

    public Slider volumSlider;
    public Toggle muteToggle;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void Start()
    {
        settingButton.onClick.AddListener(() => SettingButton());
        stageButton.onClick.AddListener(() => StageButton());

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = DataManager.Instance.CurrentVolum;
        audioSource.mute = DataManager.Instance.MuteState;

        volumSlider.value = DataManager.Instance.CurrentVolum;
        volumSlider.onValueChanged.AddListener(delegate { ChangeVolum(); });

        muteToggle.isOn = DataManager.Instance.MuteState;
        muteToggle.onValueChanged.AddListener(delegate { ChangeMute(); });
    }

    private void ChangeVolum()
    {
        DataManager.Instance.CurrentVolum = volumSlider.value;
        audioSource.volume = volumSlider.value;
    }

    private void ChangeMute()
    {
        DataManager.Instance.MuteState = muteToggle.isOn;
        audioSource.mute = muteToggle.isOn;
    }

    private void SettingButton()
    {
        stageUI.SetActive(false);
        settingUI.SetActive(true);
    }

    private void StageButton()
    {
        stageUI.SetActive(true);
        settingUI.SetActive(false);
    }
}
