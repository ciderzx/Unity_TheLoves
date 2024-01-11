using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceObject : ColliderHandler
{
    [Header("Setting")]
    public float _pieceRotateSpeed = 3f;

    protected override void CollideEvent(Collider2D collider2D)
    {
        if (collider2D.transform.GetComponent<Actor>())
        {
            gameObject.SetActive(false);
            PieceManager.Instance._currentPieses++;

            PieceManager.Instance.CheckPiece();
        }
    }

    private void Update()
    {
        // 임시
        if (Camera.main.WorldToViewportPoint(this.transform.position).x < 0) GameManager.GameOverEvent();

        ObjectRotate();
    }

    private void ObjectRotate()
    {
        if (transform.rotation.y > 360)
        {
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
        }
        transform.Rotate(0, _pieceRotateSpeed, 0);
    }

}
