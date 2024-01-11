using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearedController : MonoBehaviour
{
    [Header("Clock Settings")]
    public GameObject _clockHour;
    public GameObject _clockMinute;
    public GameObject[] _clockHands;

    [Header("Images")]
    public Image[] _clearImages;
    public Sprite[] _clearSprites;

    private int countNumber = 0;

    private void Start()
    {
        SetforCleared();
    }

    private void Update()
    {
        ClockAnimation();
    }

    private void SetforCleared()
    {
        DataManager.Instance.CurrentStage = 3;
        int clear = DataManager.Instance.CurrentStage < 0 ? 0 : DataManager.Instance.CurrentStage;
        int[] arr = { 0, 60, 180, 300 };

        for (int index = 0; index < clear; index++)
        {
            Debug.Log(clear + ", " + index);
            _clearImages[index].gameObject.SetActive(true);
            _clearImages[index].color = Color.white;
            StartCoroutine(ClearImageLoad(index));
        }
        _clockHour.transform.Rotate(0, 0, arr[clear]);
        /*switch (clear)
        {
            case 1:
           
                
                _clearImages[0].gameObject.SetActive(true);
                _clearImages[0].color = new Color(1f, 1f, 1f, 1f);
                StartCoroutine(ClearImageLoad(0));
                _clockHour.transform.Rotate(0, 0, 60);
                break;
            case 2:
                _clearImages[1].gameObject.SetActive(true);
                _clearImages[1].color = new Color(1f, 1f, 1f, 1f);
                StartCoroutine(ClearImageLoad(1));
                _clockHour.transform.Rotate(0, 0, 180);
                break;
            case 3:
                // 임시 부분
                _clearImages[2].gameObject.SetActive(true);
                _clearImages[2].color = new Color(1f, 1f, 1f, 1f);
                StartCoroutine(ClearImageLoad(2));
                //
                _clockHour.transform.Rotate(0, 0, 300);
                break;
        }*/
    }

    private IEnumerator ClearImageLoad(int indexNumber)
    {

        _clearImages[indexNumber].sprite = _clearSprites[indexNumber];
        _clearImages[indexNumber].color = new Color(1f, 1f, 1f, 0f);

        while (_clearImages[indexNumber].color.a < 1)
        {
            _clearImages[indexNumber].color += Color.white * (Time.deltaTime * 0.5f);

            yield return null;
        }
    }

    private void ClockAnimation()
    {
        // 첫번째 배경 시계 애니메이션
        _clockHands[0].transform.Rotate(_clockHands[0].transform.rotation.x, _clockHands[0].transform.rotation.y, 2.5f);

        // 두번째 배경 시계 애니메이션
        _clockHands[1].transform.Rotate(_clockHands[1].transform.rotation.x, _clockHands[1].transform.rotation.y, -2.5f);

        // 세번째 배경 시계 애니메이션
        _clockHands[2].transform.Rotate(_clockHands[2].transform.rotation.x, _clockHands[2].transform.rotation.y, 3);

        // 네번째 배경 시계 애니메이션
        _clockHands[3].transform.Rotate(_clockHands[3].transform.rotation.x, _clockHands[3].transform.rotation.y, 1.5f);
    }

    public IEnumerator ClickTimeEvent(string stageNm)
    {
        int stageNumberInt = int.Parse(stageNm);
        if (stageNumberInt <= DataManager.Instance.CurrentStage)
        {
            LoadingSceneManager.LoadScene("Stage " + stageNm);
            yield break;
        }
        int[] arr = { 60, 180, 300};
        int endPos = DataManager.Instance.CurrentStage > 0 ? 120 : arr[stageNumberInt-1];

        while ((countNumber * stageNumberInt < endPos))
        {
            _clockHour.transform.Rotate(0, 0, 1 * stageNumberInt);   
            _clockMinute.transform.Rotate(0, 0, 12 * stageNumberInt);

            countNumber++;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1.5f);

        LoadingSceneManager.LoadScene("Stage " + stageNm);
    }
}
