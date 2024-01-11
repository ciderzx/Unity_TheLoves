using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverManager : MonoSingleton<OverManager>
{
    [Header("Setting")]
    public GameObject playerStPoint;
    public GameObject dasomStPoint;
    public GameObject auroraStPoint;

    [Space(10)]

    public Vector3 cameraStVector;
    public Vector3 backgroundStVector;

    private Actor player;
    private Actor dasom;
    private AuroraController aurora;
    public Camera mainCamera;
    public GameObject backScroll;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>().GetComponent<Actor>();
        DasomController dasomController = GameObject.FindObjectOfType<DasomController>();
        if(dasomController != null) dasom = dasomController.GetComponent<Actor>();

        aurora = GameObject.FindObjectOfType<AuroraController>();
    }

    private void Start()
    {
        GameManager.GameOverEvent += Over;
    }

    private void Over()
    {
        player.transform.position = playerStPoint.transform.position;
        if (dasom != null) dasom.transform.position = dasomStPoint.transform.position;

        aurora.transform.position = auroraStPoint.transform.position;
        mainCamera.transform.position = cameraStVector;
        backScroll.transform.position = backgroundStVector;
    }
}
