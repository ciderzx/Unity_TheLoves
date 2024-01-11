using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string _nextScene;

    public Button _skipButton;

    private bool _skipType = false;
    private float _checkTime = 0f;

    private void Start()
    {
        _skipButton.gameObject.SetActive(false);
        _skipButton.onClick.AddListener(() => SkipButton());
        StartCoroutine(LoadScene());
    }

    private void Update()
    {
        _checkTime += Time.deltaTime;
    }

    public static void LoadScene(string sceneName)
    {
        _nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation operationScene = SceneManager.LoadSceneAsync(_nextScene);

        operationScene.allowSceneActivation = false;

        while (!operationScene.isDone)
        {
            yield return null;

            if (operationScene.progress >= 0.9f)
            {
                _skipButton.gameObject.SetActive(true);
                if (_skipType || _checkTime > 2.5f)
                {
                    operationScene.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private void SkipButton()
    {
        _skipType = true;
    }
}
