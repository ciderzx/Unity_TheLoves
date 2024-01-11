using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum StageType
{
    ONE,
    TWO,
    HAS_STORY
}

public class EndManager : MonoSingleton<EndManager>
{
    [Header("Setting")]
    public GameObject EndStoryUI;

    public Button _nextButton;
    public StageType _currentStage;

    public float _endDelay = 1.5f;

    private string _stageName;

    private void Awake()
    {
        _stageName = SceneManager.GetActiveScene().name;
        _nextButton.onClick.AddListener(() => EndNextScene());
        GameManager.GameEndEvent += EndPopUpEvent;
    }

    private void EndPopUpEvent()
    {
        StartCoroutine(PopupDelay());
    }

    private IEnumerator PopupDelay()
    {
        int lengthSize = GameObject.FindObjectOfType<ProductionTextController>()._endProductionStrings.Length;

        if (lengthSize <= 0)
        {
            yield return new WaitForSecondsRealtime(_endDelay);

            EndStoryUI.SetActive(true);

            yield break;
        }
        yield return new WaitForSecondsRealtime(_endDelay);

        StartCoroutine(GameObject.FindObjectOfType<ProductionTextController>().EndProductionText());

        yield return new WaitForSecondsRealtime((_endDelay * 3.5f) * lengthSize);

        EndStoryUI.SetActive(true);
    }

    private void EndNextScene()
    {
        if (_currentStage == StageType.ONE) LoadingSceneManager.LoadScene(_stageName + "-" + ((int)_currentStage + 2));
        else if (_currentStage == StageType.HAS_STORY) LoadingSceneManager.LoadScene("Story" + "_" + GameManager.Instance.stageNo);
        else
        {
            Debug.Log("aa");
            StageManager._clearedSceneNumber += 2;
            LoadingSceneManager.LoadScene("Main");
        }
    }
}
