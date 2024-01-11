using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    private int currentStage;
    public int CurrentStage
    {
        get
        {
            return currentStage;
        }

        set
        {
            currentStage = value;
            if (currentStage > 3) currentStage = 3;
            PlayerPrefs.SetInt("Current Stage", currentStage);
            PlayerPrefs.Save();
        }
    }

    private float currentVolum;
    public float CurrentVolum
    {
        get
        {
            return currentVolum;
        }

        set
        {
            currentVolum = value;
            PlayerPrefs.SetFloat("Current Volum", currentVolum);
            PlayerPrefs.Save();
        }
    }

    private float currentBGM;
    public float CurrentBGM
    {
        get
        {
            return currentBGM;
        }

        set
        {
            currentBGM = value;
            PlayerPrefs.SetFloat("Current BGM", currentBGM);
            PlayerPrefs.Save();
        }
    }

    private float currentEffectSound;
    public float CurrentEffectSound
    {
        get
        {
            return currentEffectSound;
        }

        set
        {
            currentEffectSound = value;
            PlayerPrefs.SetFloat("Current Effect Sound", currentEffectSound);
            PlayerPrefs.Save();
        }
    }

    private bool muteState;
    public bool MuteState
    {
        get
        {
            return muteState;
        }

        set
        {
            muteState = value;
            PlayerPrefs.SetString("Mute State", muteState ? "Y" : "N");
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        LoadData();
        DontDestroyOnLoad(gameObject); 
    }

    public void LoadData()
    {
        currentStage = PlayerPrefs.GetInt("Current Stage");
        currentVolum = PlayerPrefs.GetFloat("Current Volum");
        muteState = PlayerPrefs.GetString("Mute State") == "Y" ? true : false;
    }
}
