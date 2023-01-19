using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuspicion : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO playerStats;

    float currentSuspicion = 0;

    public float CurrentSuspicion
    {
        get => currentSuspicion;
        set
        {
            if (currentSuspicion != value)
            {
                timeUndetected = 0;
            }
            currentSuspicion = value;
        }
    }

    bool eventFired = false;

    public float Progress { get => Mathf.Min(1, currentSuspicion / playerStats.MaxSuspicion); }

    public bool Invincible { get; set; } = false;
    float timeUndetected = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeUndetected += Time.deltaTime;
        if (timeUndetected >= playerStats.SecondsToWaitBeforeDecreasingSuspicion)
        {
            currentSuspicion = Mathf.Max(currentSuspicion - (playerStats.SuspicionLossPerSecond * Time.deltaTime), 0);
        }
        if (currentSuspicion >= playerStats.MaxSuspicion && !eventFired && !Invincible)
        {
            GameManager.Manager.OnGameLoss.Invoke(GameOverHandler.GameOverReason.SUSPICION_MAXED);
            eventFired = true;
        }
    }


}
