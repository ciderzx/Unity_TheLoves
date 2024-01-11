using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneAnimations : MonoBehaviour
{
    [Header("Text : THE")]
    public GameObject[] text_THE;

    [Header("Text : LOVERS")]
    public SpriteRenderer[] text_LOVERS;

    [Header("Peoples")]
    public GameObject[] _peoples;

    [Header("Start")]
    public SpriteRenderer _startLogo;

    [HideInInspector] public bool _animationEnd = false;

    private AudioSource audioSource;

    private bool _animationCheck = false;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.volume = DataManager.Instance.CurrentVolum;
        audioSource.mute = DataManager.Instance.MuteState;

        StartCoroutine(FirstCoroutine());
    }

    private void Update()
    {
        if(_animationCheck && Input.touchCount >= 1)
        {
            LoadingSceneManager.LoadScene("Story_1");
        }

        if (_animationCheck && Input.GetMouseButton(0))
        {
            LoadingSceneManager.LoadScene("Story_1");
        }
    }

    private IEnumerator FirstCoroutine()
    {
        for (int index = 0; index < text_THE.Length; index++)
        {
            while (text_THE[index].transform.rotation.x >= 0)
            {
                text_THE[index].transform.Rotate(text_THE[index].transform.rotation.x + -5f, 0, 0);
                yield return null;
            }

            if (text_THE[index].transform.rotation.x < 0) text_THE[index].transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        StartCoroutine(SecondCoroutine());
    }

    private IEnumerator SecondCoroutine()
    {
        for (int index = 0; index < text_LOVERS.Length; index++ )
        {
            Color textColor = text_LOVERS[index].color;
            
            while (textColor.a < 1.0f)
            {
                if(index == 5)
                {
                    text_LOVERS[index].transform.position += new Vector3(1.21f * (Time.deltaTime * 5.0f), 0);
                }

                textColor.a += (Time.deltaTime * 5.0f);
                text_LOVERS[index].color = textColor;
                yield return null;
            }
        }
        StartCoroutine(ThirdCoroutine());
    }

    private IEnumerator ThirdCoroutine()
    {
        float position_x;

        for (int index = 0; index < _peoples.Length; index++)
        {
            Vector3 peoplePosition = _peoples[index].transform.position;

            if (index == 0) position_x = -7.7f;
            else position_x = 7f;

            while (Mathf.Abs(_peoples[index].transform.position.x) > Mathf.Abs(position_x))
            {
                _peoples[index].transform.position += new Vector3(-position_x * (Time.deltaTime * 2f), 0);
                yield return null;
            }
        }

        StartCoroutine(LastCoroutine());
    }

    private IEnumerator LastCoroutine()
    {
        Color textColor = _startLogo.color;

        while (textColor.a < 1.0f)
        {
            textColor.a += (Time.deltaTime * 5.0f);
            _startLogo.color = textColor;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(2.0f);

        _animationCheck = true;
    }
}
