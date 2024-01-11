using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    private Camera _cameara;
    private Actor _player;

    [Header("Scrolling Interations")]
    public float _scrollOffsetSpeed;

    private float _offset;
    private Renderer _meshRenderer;
    private float _scrollSpeed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _player = GameObject.FindObjectOfType<PlayerController>().GetComponent<Actor>();
        _cameara = GameObject.FindObjectOfType<CameraController>().GetComponent<Camera>();
    }

    private void Update()
    {
        ScrollCheck();
    }

    public void ScrollOffsetMove()
    {
        _offset += Time.deltaTime * _scrollOffsetSpeed;
        _meshRenderer.material.mainTextureOffset = new Vector2(_offset, 0);
    }

    public void ScrollMove()
    {
        Vector3 moveDir = Vector3.right;
        moveDir.Normalize();

        _scrollSpeed = _player.moveSpeed;

        transform.position += moveDir * _scrollSpeed * Time.deltaTime;
    }

    private void ScrollCheck()
    {
        if (!CameraController.GetCameraMove || TimeManager.Instance.GetPause()) return;

        ScrollMove();
        ScrollOffsetMove();
    }
}
