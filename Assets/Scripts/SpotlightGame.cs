using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpotlightGame : MonoBehaviour
{
    [SerializeField]
    Color normalColor;

    public Color NormalColor { get => normalColor; }

    [SerializeField]
    Color badColor;

    public Color BadColor { get => badColor; }

    [SerializeField]
    Light spotlight;

    public Light Light { get => spotlight; }

    public UnityEvent OnPlayerDetected;
}
