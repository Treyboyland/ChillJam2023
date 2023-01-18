using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "Game/Float Value")]
public class FloatValue : ScriptableObject
{
    [SerializeField]
    float value;

    public float Value { get => value; }
}
