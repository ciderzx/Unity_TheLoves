using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraController : ColliderHandler
{
    [Header("Aurora Interation")]
    public float _auroraSpeed;
    public bool controlSpeed;
    
    [Header("Aurora Auto Speed ( Control Speed == false )")]
    public float _auroraMinusSpeed;

    private float _auroraSpeed_off;

    private Actor _player;

    protected override void CollideEvent(Collider2D collider)
    {
        if (collider.transform.GetComponent<Actor>())
        {
            GameManager.GameOverEvent();
        }
    }

    private void Awake()
    {
        _player = GameObject.FindObjectOfType<PlayerController>().GetComponent<Actor>();
    }

    private void Update()
    {
        AuroraMove();
    }

    private void AuroraMove()
    {
        _auroraSpeed_off = _player.moveSpeed - _auroraMinusSpeed;
        if (!controlSpeed) _auroraSpeed = _auroraSpeed_off;

        Vector3 moveVec = Vector3.right;
        moveVec.Normalize();

        if (TimeManager.Instance.GetPause()) return;

        transform.position += moveVec * _auroraSpeed * Time.deltaTime;
    }
}