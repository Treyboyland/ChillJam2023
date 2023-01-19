using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CowRandomizer", menuName = "Game/Cow Randomizer")]
public class CowRandomizer : ScriptableObject
{
    [SerializeField]
    Vector2 size;

    public Vector3 Size
    {
        get
        {
            var scale = size.Random();

            return new Vector3(scale, scale, scale);
        }
    }

    [SerializeField]
    Vector2 mass;

    public float Mass { get => mass.Random(); }

    [SerializeField]
    Vector2 angularMultiplier;

    public float AngularMultiplier { get => angularMultiplier.Random(); }

    [SerializeField]
    Vector2 xFlipVelocity;

    [SerializeField]
    Vector2 yFlipVelocity;

    [SerializeField]
    Vector2 zFlipVelocity;

    [SerializeField]
    Vector2 flipPower;

    public Vector3 FlipVelocity
    {
        get
        {
            return new Vector3(xFlipVelocity.Random(), yFlipVelocity.Random(), zFlipVelocity.Random());
        }
    }

    public float FlipPower { get => flipPower.Random(); }

    [SerializeField]
    List<Material> materials;

    public Material Material { get => materials.Random(); }

    [SerializeField]
    Vector2 rotationRandom;

    public float RotationWalk { get => rotationRandom.Random(); }

    [SerializeField]
    Vector2 walkRandomTime;

    public float WalkTime { get => walkRandomTime.Random(); }

    [SerializeField]
    Vector2 waitTime;

    public float WaitTimeWalk { get => waitTime.Random(); }

    [SerializeField]
    Vector2 walkSpeedRandom;

    public float WalkSpeed { get => walkSpeedRandom.Random(); }

    [SerializeField]
    float spawnBombProbability;

    public bool ShouldSpawnBomb { get => Random.Range(0, 1.0f) < spawnBombProbability; }

    [SerializeField]
    float secondsToWaitBeforeBomb;

    public float SecondsToWaitBeforeBomb { get => secondsToWaitBeforeBomb; }
}
