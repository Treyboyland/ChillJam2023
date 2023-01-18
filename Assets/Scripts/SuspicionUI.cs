using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionUI : MonoBehaviour
{
    [SerializeField]
    Gradient barColor;

    [SerializeField]
    Image image;

    [SerializeField]
    PlayerSuspicion suspicion;

    // Update is called once per frame
    void Update()
    {
        var progress = suspicion.Progress;
        image.color = barColor.Evaluate(progress);
        image.fillAmount = progress;
    }
}
