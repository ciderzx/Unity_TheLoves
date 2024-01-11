using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : ColliderHandler
{
    protected override void CollideEvent(Collider2D collider)
    {
        if(collider.GetComponent<PlayerController>())
        {
            GameManager.GameEndEvent();
            gameObject.SetActive(false);
        }
    }
    
}
