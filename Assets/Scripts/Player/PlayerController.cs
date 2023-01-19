using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerEnergy energy;

    [SerializeField]
    PlayerStatsSO stats;

    [SerializeField]
    Rigidbody body;

    public bool CanMove { get; set; } = true;

    private void FixedUpdate()
    {
        if (energy.CanPerformActions && CanMove)
        {
            Move();
        }
    }

    private void Update()
    {
        energy.CanIncrease = !Input.GetButton("Sprint");
    }

    void Move()
    {
        //Move faster diagonally
        var y = body.transform.forward * Input.GetAxis("Vertical") * stats.Speed;
        var x = body.transform.right * Input.GetAxis("Horizontal") * stats.Speed;
        var translation = y + x;

        if (Input.GetButton("Sprint") && energy.CanPerformAction(PlayerStatsSO.PlayerAction.SPRINT)
            && translation != Vector3.zero)
        {
            energy.PerformAction(PlayerStatsSO.PlayerAction.SPRINT);
            translation *= stats.SprintMultiplier;
            GameManager.Manager.OnPlayerSprint.Invoke(true);
        }
        else
        {
            GameManager.Manager.OnPlayerSprint.Invoke(false);
        }

        var vector = translation;

        //Debug.LogWarning("Movement Vector: " + vector);

        body.velocity = vector;
    }
}
