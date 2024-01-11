using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColliderHandler : MonoBehaviour
{
    protected abstract void CollideEvent(Collider2D collider);

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        CollideEvent(collision);
    }
}
