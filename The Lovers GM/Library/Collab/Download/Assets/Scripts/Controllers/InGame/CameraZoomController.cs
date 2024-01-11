using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    private Camera _camera;

    public const int MAX_CAMERA_SIZE = 5;
    public const int MIN_CAMERA_SIZE = 2;

    [Header("Target")]
    public Transform _targetPos;

    [Header("Zoom In")]
    public float _zoomInSizeSpeed;
    public float _zoomInMoveSpeed;

    [Header("Zoom Out")]
    public float _zoomOutSizeSpeed;
    public float _zoomOutMoveSpeed;

    [Header("Rotate")]
    public float _rotateSpeed;
    public float _rotateZ;

    // 회전 여부 ( 테스트 용 )
    public bool _onRotate;

    private float currentRotate = 0;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        GameManager.GameInitEvent += Init;
        GameManager.GameEndEvent += End;
        //StartCoroutine(CameraZoomOut());
    }

    private void Init()
    {
        StartCoroutine(CameraZoomOut());
    }

    private void End()
    {
        StartCoroutine(CameraZoomIn());
    }

    public IEnumerator CameraZoomOut()
    {
        Vector3 moveDir = new Vector3(5, 3, 0);

        while (_camera.orthographicSize < MAX_CAMERA_SIZE)
        {
            _camera.orthographicSize += (_zoomOutSizeSpeed - 1f) * Time.deltaTime;
            if (transform.position.x <= 0 && transform.position.y <= 0)
            {
                transform.position += moveDir.normalized * Time.deltaTime * (_zoomOutMoveSpeed + 1.75f);
            }

            yield return null;
        }
        _camera.orthographicSize = MAX_CAMERA_SIZE;
        transform.position = new Vector3(transform.position.x, 0, -10);

         yield return null;
    }

    public IEnumerator CameraZoomIn()
    {
        yield return new WaitForSeconds(0.6f);

        Vector3 moveDir = new Vector3(0, -3, 0);

        // Rotate 부분 뺄꺼면, 인스팩터에서 On Rotate true로 체크

        bool successMove = false;
        bool successSize = false;
        bool successRotate = false;

        while (!successMove || !successSize || !successRotate)
        {
            //[1] 카메라 이동
            if (transform.position.y <= moveDir.y) successMove = true;
            else transform.position += moveDir.normalized * Time.deltaTime * (_zoomInMoveSpeed + 1.75f);

            //[2] 카메라 사이즈
            if (_camera.orthographicSize < MIN_CAMERA_SIZE) successSize = true;
            else _camera.orthographicSize -= (_zoomInSizeSpeed - 1f) * Time.deltaTime;

            //[3] 카메라 회전
            if (currentRotate >= _rotateZ || !_onRotate) successRotate = true;
            else { transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime); currentRotate += _rotateSpeed * Time.deltaTime; }

            yield return null;
        }

        _camera.orthographicSize = MIN_CAMERA_SIZE;
        transform.position = new Vector3(transform.position.x, moveDir.y, -10);
    }
}