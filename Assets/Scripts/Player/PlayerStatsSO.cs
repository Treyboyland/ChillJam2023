using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Game/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField]
    int maxLives;

    public int MaxLives { get => maxLives; }

    [SerializeField]
    float maxEnergy;

    public float MaxEnergy { get => maxEnergy; }

    [SerializeField]
    float energyPerSecond;

    public float EnergyPerSecond { get => energyPerSecond; }

    [SerializeField]
    float flipCost;

    public float FlipCost { get => flipCost; }

    [SerializeField]
    float sprintCostPerSecond;

    public float SprintCostPerSecond { get => sprintCostPerSecond; }

    [SerializeField]
    float speed;

    public float Speed { get => speed; }

    [SerializeField]
    float sprintMultiplier;

    public float SprintMultiplier { get => sprintMultiplier; }

    [SerializeField]
    float maxSuspicion;

    public float MaxSuspicion { get => maxSuspicion; }

    [SerializeField]
    float secondsToWaitBeforeDecreasingSuspicion;

    public float SecondsToWaitBeforeDecreasingSuspicion { get => secondsToWaitBeforeDecreasingSuspicion; }

    [SerializeField]
    float suspicionLossPerSecond;

    public float SuspicionLossPerSecond { get => suspicionLossPerSecond; }

    public enum PlayerAction
    {
        FLIP,
        SPRINT
    }
}
