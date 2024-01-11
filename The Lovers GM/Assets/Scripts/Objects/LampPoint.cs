using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPoint : ColliderHandler
{
    [Header("Setting")]
    public GameObject _lampOBJ;
    public Sprite _onStreetLamp;

    protected override void CollideEvent(Collider2D collider)
    {
        _lampOBJ.transform.GetChild(0).gameObject.SetActive(false);
        _lampOBJ.transform.GetChild(1).gameObject.SetActive(false);
        _lampOBJ.GetComponent<SpriteRenderer>().sprite = _onStreetLamp;
        this.gameObject.SetActive(false);
    }

}
