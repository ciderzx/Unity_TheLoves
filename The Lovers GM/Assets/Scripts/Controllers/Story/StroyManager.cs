using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StroyManager : MonoBehaviour
{
    public string nextSceneNm;
    public Button skipButton;

    public float skipTiming;

    private void Awake()
    {
        skipButton.onClick.AddListener(() => SkipStory());
        skipButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(SkipButtonAnim());
    }

    private IEnumerator SkipButtonAnim()
    {
        yield return new WaitForSeconds(skipTiming);

        skipButton.gameObject.SetActive(true);

        Text text = skipButton.GetComponentInChildren<Text>();

        for (float count = 0; text.color.a < 1f; count += 1 * Time.deltaTime)
        {
            yield return null;

            text.color += new Color(0, 0, 0, 0.005f);
        }
    }

    private void SkipStory()
    {
        LoadingSceneManager.LoadScene(nextSceneNm);
    }
}
