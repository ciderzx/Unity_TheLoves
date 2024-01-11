using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    INIT,
    START,
    END,
    PLAY
}

public class GameManager : MonoBehaviour
{
    public static GameState currentGameState;

    public delegate void OverHandler();
    public static OverHandler GameOverEvent;

    public delegate void InitHandler();
    public static InitHandler GameInitEvent;

    public delegate void EndHandler();
    public static EndHandler GameEndEvent;

    [Header("Setting")]
    public GameObject GameUI;
    public GameObject StoryUI;

    private void Awake()
    {
        GameInitEvent = Init;
        GameEndEvent = End;
        GameOverEvent = Over;
    }

    private void Start()
    {
        
    }

    private void Init()
    {
           
    }

    private void End()
    {

    }

    private void Over()
    {
        
    }

}
