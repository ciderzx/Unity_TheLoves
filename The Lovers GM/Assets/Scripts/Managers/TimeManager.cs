using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoSingleton<TimeManager>
{
    private bool isOver;

    private bool isPause;
    public bool GetPause()
    {
        return isPause;
    }
    public void SetPause(bool value)
    {
        isPause = value;
    }

    [Header("Setting")]
    public Sprite[] pauseButtonSprites;

    public Button pauseButton;
    public Image pauseImage;
    public Image overImage;
    public Image endImage;

    private void Awake()
    {
        pauseButton.onClick.AddListener(() => Pause());
    }

    private void Start()
    {
        GameManager.GameInitEvent += Init;
        GameManager.GameEndEvent += End;
        GameManager.GameOverEvent += Over;
        //StartCoroutine(StartPauseTime());
    }

    private void Pause()
    {
        isPause = !isPause;

        pauseImage.gameObject.SetActive(isPause);

        if (!isPause) { pauseButton.image.sprite = pauseButtonSprites[0]; Time.timeScale = 1; } // Start
        else { pauseButton.image.sprite = pauseButtonSprites[1]; Time.timeScale = 0; } // Pause

    }

    private void Init()
    {
        isPause = true;
    }

    private void End()
    {
        isPause = true;
        endImage.gameObject.SetActive(true);
        //Time.timeScale = 0;
    }

    private void Over()
    {
        if (isOver) return;

        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        isOver = true;
        isPause = true;

        pauseButton.gameObject.SetActive(false);

        overImage.gameObject.SetActive(true);

        WaitForSeconds wait = new WaitForSeconds(0.1f);

        Color aColor = new Color(0, 0, 0, 0.1f);

        for(int index = 0; index < 10; index++)
        {
            overImage.color += aColor;
            yield return wait;
        }

        yield return new WaitForSeconds(1.5f);

        for (int index = 0; index < 10; index++)
        {
            overImage.color -= aColor;
            yield return wait;
        }

        overImage.gameObject.SetActive(false);

        pauseButton.gameObject.SetActive(true);

        isPause = false;
        isOver = false;
    }
}
