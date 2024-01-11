using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image _imageObject;

    public Sprite[] _storyImages;

    private void Start()
    {
        StartCoroutine(StoryImagesControl());
    }

    private IEnumerator StoryImagesControl()
    {
        Color Color = new Color(1f, 1f, 1f, 1f);

        for (int index = 0; index < _storyImages.Length; index++)
        {
            _imageObject.sprite = _storyImages[index];

            while (_imageObject.color.a < 1)
            {
                _imageObject.color += Color * (Time.deltaTime * 0.5f);

                yield return null;
            }
            yield return new WaitForSecondsRealtime(1.0f);

            while (_imageObject.color.a > 0)
            {
                _imageObject.color -= Color * (Time.deltaTime * 0.5f);

                yield return null;
            }
            yield return null;
        }

        LoadingSceneManager.LoadScene("Main");
    }
}
