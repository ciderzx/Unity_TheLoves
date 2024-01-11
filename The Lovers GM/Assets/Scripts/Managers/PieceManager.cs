using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceManager : MonoSingleton<PieceManager>
{
    [HideInInspector] public int _currentPieses = 0;

    [Header("Piece Interation")]
    public Text _pieceNumber;
    public GameObject _pieceObjects;
    public GameObject _objectImage;
    public int _pieceObjectsMax;
    public GameObject endPoint;

    private PieceObject[] _childPieces;
    private Image _clearPieceImage;

    private void Awake()
    {
        InitSetting();
    }

    private void Start()
    {
        GameManager.GameOverEvent += OverPieces;
    }

    private void InitSetting()
    {
        _childPieces = _pieceObjects.GetComponentsInChildren<PieceObject>();
        _clearPieceImage = _objectImage.GetComponentInChildren<Image>();
        _pieceObjectsMax = _childPieces.Length;
        _pieceNumber.text = _currentPieses + " / " + _pieceObjectsMax;
        //endPoint.SetActive(false);

        OverPieces();
    }

    private void Update()
    {
        TextByPiece();
    }

    private void OverPieces()
    {
        _currentPieses = 0;

        for (int index = 0; index < _childPieces.Length; index++)
        {
            _childPieces[index].gameObject.SetActive(true);
        }
        _clearPieceImage.gameObject.SetActive(false);
    }

    private void TextByPiece()
    {
        _pieceNumber.text = _currentPieses + " / " + _pieceObjectsMax; 
    }

    public void CheckPiece()
    {
        if(_currentPieses >= _pieceObjectsMax)
        {
            _clearPieceImage.gameObject.SetActive(true);
            endPoint.SetActive(true);
        }
    }
}