using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject pDefaultView;
    public GameObject pSettingView;

    public Button defaultViewButton;
    public Button settingViewButton;

    public Button homeButton;

    private void Awake()
    {
        defaultViewButton.onClick.AddListener(() => ShowDefaultView());
        settingViewButton.onClick.AddListener(() => ShowSettingView());

        homeButton.onClick.AddListener(() => HomeButton());
    }

    private void ShowDefaultView()
    {
        pSettingView.SetActive(false);
        pDefaultView.SetActive(true);
    }

    private void ShowSettingView()
    {
        pSettingView.SetActive(true);
        pDefaultView.SetActive(false);
    }

    private void HomeButton()
    {
        Time.timeScale = 1;
        LoadingSceneManager.LoadScene("Main");
    }
}
