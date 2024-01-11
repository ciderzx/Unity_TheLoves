using UnityEngine;
using UnityEngine.UI;

public class DummyVisual : Graphic
{
    protected override void Awake()
    {
        base.Awake();

        color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
}