using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ContainerMoveType
{
    RIGHT,
    LEFT
}

public class PageContainerMove : MonoBehaviour
{
    [Header("Page container")]
    public GameObject _pageContainer;
    public int _pageWidth;

    [Header("Buttons")]
    public GameObject _leftButton;
    public GameObject _rightButton;

    private ContainerMoveType _currentType;
    private bool _animationPlaying = false;

    public int _leftEndPoint;
    public int _rightEndPoint;

    private void Awake()
    {
        _leftButton.GetComponent<Button>().onClick.AddListener(() => LeftContainer());
        _rightButton.GetComponent<Button>().onClick.AddListener(() => RightContainer());
    }

    private void FixedUpdate()
    {
        ButtonsActiveCheck();
    }

    private void ButtonsActiveCheck()
    {
        // left button check
        if (_pageContainer.transform.localPosition.x > _leftEndPoint) _leftButton.SetActive(false);
        else _leftButton.SetActive(true);

        // right button check
        if (_pageContainer.transform.localPosition.x < _rightEndPoint) _rightButton.SetActive(false);
        else _rightButton.SetActive(true);
    } 

    public void LeftContainer()
    {
        _currentType = ContainerMoveType.LEFT;

        if (_pageContainer.transform.localPosition.x > _leftEndPoint) return;

        Move(_currentType);
    }

    public void RightContainer()
    {
        _currentType = ContainerMoveType.RIGHT;

        if (_pageContainer.transform.localPosition.x < _rightEndPoint) return;

        Move(_currentType);
    }

    private void Move(ContainerMoveType moveType)
    {
        if (_animationPlaying) return;

        _animationPlaying = true;
        StartCoroutine(AnimationMove(moveType));
    }

    private IEnumerator AnimationMove(ContainerMoveType moveType)
    {
        Vector3 pageMoveVector = new Vector3(_pageWidth * 0.2f, 0);

        if (moveType == ContainerMoveType.LEFT)
        {
            for (int i = 0; i < 5; i++)
            {
                _pageContainer.transform.localPosition += pageMoveVector;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                _pageContainer.transform.localPosition -= pageMoveVector;
                yield return new WaitForEndOfFrame();
            }
        }

        _animationPlaying = false;
    }
}
