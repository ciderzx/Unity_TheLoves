using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    public const int MAX_CAMERA_SIZE = 5;
    public const int MIN_CAMERA_SIZE = 2;

    [Header("Target")]
    public Transform _targetPos;

    [Header("Setting")]
    public float _speed;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        StartCoroutine(CameraZoomOut());
    }

    public IEnumerator CameraZoomOut()
    {
        Vector3 moveDir = new Vector3(5, 3, 0);

        while (_camera.orthographicSize <= MAX_CAMERA_SIZE)
        {
            _camera.orthographicSize += (_speed - 1f) * Time.deltaTime;

            if (transform.position.x <= 0 && transform.position.y <= 0)
            {
                transform.position += moveDir.normalized * Time.deltaTime * (_speed + 1.75f);
            }

            yield return null;
        }

        _camera.orthographicSize = 5f;
        transform.position = new Vector3(transform.position.x, 0, -10);

         yield return null;
    }

    public IEnumerator CameraZoomIn()
    {
        while (_camera.orthographicSize > MIN_CAMERA_SIZE)
        {
            Debug.Log(_camera.orthographicSize);
            _camera.orthographicSize -= Time.deltaTime * (_speed - 1f);

            yield return null;
        }

        _camera.orthographicSize = 2f;

        yield return null;
    }

}