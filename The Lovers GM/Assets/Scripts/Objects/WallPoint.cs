using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallPoint : ColliderHandler
{
    public GameObject wall;

    protected override void CollideEvent(Collider2D collider)
    {
        if(collider.GetComponent<PlayerController>())
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
            StartCoroutine(Coroutine());
        }
            
    }

    IEnumerator Coroutine()
    {
        for (int index = 0; wall.GetComponent<SpriteRenderer>().size.y >= 0; index++)
        {
            yield return null;
            wall.GetComponent<BoxCollider2D>().size = new Vector2(wall.GetComponent<BoxCollider2D>().size.x, wall.GetComponent<BoxCollider2D>().size.y - 0.1f);
            wall.GetComponent<SpriteRenderer>().size = new Vector2(wall.GetComponent<SpriteRenderer>().size.x, wall.GetComponent<SpriteRenderer>().size.y - 0.1f);
        }
    }

}
