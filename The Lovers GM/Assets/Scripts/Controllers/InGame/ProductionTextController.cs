using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionTextController : MonoBehaviour
{
    public Text _showText;

    public string[] _startProductionStrings;
    public string[] _endProductionStrings;

    public IEnumerator StartProductionText(float textSpeed, float nextDelay)
    {
        Color Color = new Color(1f, 1f, 1f, 1f);

        _showText.gameObject.SetActive(true);

        for (int index = 0; index < _startProductionStrings.Length; index++)
        {
            _showText.text = _startProductionStrings[index];
            //_showText.color = new Color(0, 0, 0, 0);

            while (_showText.color.a < 1)
            {
                _showText.color += Color * (Time.deltaTime * textSpeed);

                yield return null;
            }

            yield return new WaitForSecondsRealtime(nextDelay);

            while (_showText.color.a > 0)
            {
                _showText.color -= Color * (Time.deltaTime * textSpeed);

                yield return null;
            }
            yield return null;
        }
        _showText.gameObject.SetActive(false);

        TimeManager.Instance.SetPause(false);
    }

    public IEnumerator EndProductionText()
    {
        Color Color = new Color(1f, 1f, 1f, 1f);

        _showText.gameObject.SetActive(true);

        for (int index = 0; index < _endProductionStrings.Length; index++)
        {
            _showText.text = _endProductionStrings[index];

            while (_showText.color.a < 1)
            {
                _showText.color += Color * (Time.deltaTime * 0.5f);

                yield return null;
            }
            yield return new WaitForSecondsRealtime(1.0f);

            while (_showText.color.a > 0)
            {
                _showText.color -= Color * (Time.deltaTime * 0.5f);

                yield return null;
            }
            yield return null;
        }

        _showText.gameObject.SetActive(false);

        yield return null;
    }

}
