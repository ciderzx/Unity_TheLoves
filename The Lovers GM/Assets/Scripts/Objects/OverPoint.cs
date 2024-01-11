using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverPoint : ColliderHandler
{
    protected override void CollideEvent(Collider2D collider)
    {
        if(collider.GetComponent<Actor>())
        {
            GameManager.GameOverEvent();
        }
    }
}
