using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoSingleton<StartManager>
{
    [Header("Setting")]
    public GameObject _startObjects;
    public float _themeDeleteDelay;

    [Space]
    public float _startTextSpeed;
    public float _startNextDelay;

    private Image _backgroundImage;
    private Text _currentStageTheme;

    private void Awake()
    {
        _backgroundImage = _startObjects.GetComponent<Image>();
        _currentStageTheme = _startObjects.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        StartCoroutine(StartInitEvent());
    }

    private IEnumerator StartInitEvent()
    {
        Color Color = new Color(0, 0, 0, 1f);

        yield return new WaitForSecondsRealtime(_themeDeleteDelay);

        while (_backgroundImage.color.a > 0 || _currentStageTheme.color.a > 0)
        {
            _backgroundImage.color -= Color * Time.deltaTime;
            _currentStageTheme.color -= Color * Time.deltaTime;

            yield return null;
        }

        _startObjects.SetActive(false);
        StartCoroutine(GameObject.FindObjectOfType<ProductionTextController>().StartProductionText(_startTextSpeed, _startNextDelay));
    }
}
