using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AlphaHitTestThresholdModulator : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float alphaHitTestTreshold = 0.0f;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alphaHitTestTreshold;
    }
}