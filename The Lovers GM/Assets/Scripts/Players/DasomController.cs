using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasomController : MonoBehaviour
{
    private Actor actor;

    void Awake()
    {
        actor = GetComponent<Actor>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        actor.TryMove(Vector3.right);
    }
}
