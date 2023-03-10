using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO stats;

    float currentEnergy;

    public float Percentage => currentEnergy / stats.MaxEnergy;

    public bool CanIncrease { get; set; } = true;

    public UnityEvent<PlayerStatsSO.PlayerAction> OnActionPerformed;

    public bool CanPerformActions = true;

    // Start is called before the first frame update
    void Awake()
    {
        currentEnergy = stats.MaxEnergy;
    }

    private void Start()
    {
        GameManager.Manager.OnGameLoss.AddListener(unused => CanPerformActions = false);
    }

    private void Update()
    {
        if (CanIncrease && CanPerformActions)
        {
            currentEnergy = Mathf.Min(currentEnergy + Time.deltaTime * stats.EnergyPerSecond, stats.MaxEnergy);
        }
    }

    public bool CanPerformAction(PlayerStatsSO.PlayerAction action)
    {
        if (!CanPerformActions)
        {
            return false;
        }

        switch (action)
        {
            case PlayerStatsSO.PlayerAction.FLIP:
                return currentEnergy >= stats.FlipCost;
            case PlayerStatsSO.PlayerAction.SPRINT:
                return currentEnergy >= stats.SprintCostPerSecond * Time.deltaTime;
            default:
                return false;
        }
    }

    internal void PerformAction(PlayerStatsSO.PlayerAction action)
    {
        switch (action)
        {
            case PlayerStatsSO.PlayerAction.FLIP:
                currentEnergy -= stats.FlipCost;
                break;
            case PlayerStatsSO.PlayerAction.SPRINT:
                currentEnergy -= stats.SprintCostPerSecond * Time.deltaTime;
                break;
        }
        OnActionPerformed.Invoke(action);
    }
}
