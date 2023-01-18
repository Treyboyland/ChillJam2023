using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuspicion : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO playerStats;

    float currentSuspicion = 0;

    public float CurrentSuspicion { get => currentSuspicion; set => currentSuspicion = value; }

    bool eventFired = false;

    public float Progress { get => Mathf.Min(1, currentSuspicion / playerStats.MaxSuspicion); }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSuspicion >= playerStats.MaxSuspicion && !eventFired)
        {
            GameManager.Manager.OnGameLoss.Invoke(GameOverHandler.GameOverReason.SUSPICION_MAXED);
            eventFired = true;
        }
    }


}
