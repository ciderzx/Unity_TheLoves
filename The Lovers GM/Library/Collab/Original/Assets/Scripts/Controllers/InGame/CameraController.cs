using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static bool canCameraMove;
    public static bool GetCameraMove
    {
        get { return canCameraMove; }
    }

    private Camera _camera;
    private Actor _player;

    public float _cameraMoveSpeed;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _player = GameObject.FindObjectOfType<PlayerController>().GetComponent<Actor>();
    }

    private void Start()
    {
            
    }

    private void Update()
    {
        canCameraMove = PlayerPointCheck();
        CameraMovement();
    }

    private void CameraMovement()
    {
        if (!PlayerPointCheck()) return;

        Vector3 moveVec = Vector3.right;
        moveVec.Normalize();

        transform.position += moveVec * _cameraMoveSpeed * Time.deltaTime;
    }


    public bool PlayerPointCheck()
    {
        float _playerPoint = _camera.WorldToViewportPoint(_player.transform.position).x;

        if (_playerPoint < 0.5f) return false;

        return true;
    }
}
