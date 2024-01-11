using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    INIT,
    START,
    END
}

public class GameManager : MonoSingleton<GameManager>
{
    public delegate void OverHandler();
    public static OverHandler GameOverEvent;

    public delegate void InitHandler();
    public static InitHandler GameInitEvent;

    public delegate void EndHandler();
    public static EndHandler GameEndEvent;

    [Header("Setting")]
    public GameObject GameUI;

    public int stageNo;
    public bool isEndStage;

    private void Awake()
    {
        GameInitEvent = Init;
        GameEndEvent = End;
        GameOverEvent = Over;
    }

    private void Start()
    {
        GameInitEvent();
    }

    private void Init()
    {
        
    }

    private void End()
    {
        int currentStage = DataManager.Instance.CurrentStage;
        if (isEndStage && currentStage <= stageNo) DataManager.Instance.CurrentStage = stageNo + 1;
        GameUI.SetActive(false);
    }

    private void Over()
    {
        
    }
}
