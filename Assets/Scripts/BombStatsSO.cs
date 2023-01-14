using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombStats", menuName = "Game/Bomb Stats")]
public class BombStatsSO : ScriptableObject
{
    [SerializeField]
    float secondsBeforeFast;

    public float SecondsBeforeFast { get => secondsBeforeFast; }

    [SerializeField]
    float secondsBeforeExplosion;

    public float SecondsBeforeExplosion { get => secondsBeforeExplosion; }
}
