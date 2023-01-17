using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpotlightStats", menuName = "Game/Spotlight Stats")]
public class SpotlightStatsSO : ScriptableObject
{
    [SerializeField]
    float speed;

    public float Speed { get => speed; }

    [SerializeField]
    Vector4 bounds;

    public Vector4 Bounds { get => bounds; }

    [SerializeField]
    float distanceFromBounds;

    public float DistanceFromBounds { get => distanceFromBounds; }

    public enum Directions
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    [SerializeField]
    Vector2 secondsBetweenMovesRandom;

    public float SecondsBetweenMove { get => secondsBetweenMovesRandom.Random(); }

    [SerializeField]
    Vector2 secondsPerMoveRandom;

    public float SecondsPerMove { get => secondsPerMoveRandom.Random(); }

    [SerializeField]
    Vector2Int moveTowardsPlayer;

    public int MoveToPlayerCount { get => moveTowardsPlayer.Random(); }
}
