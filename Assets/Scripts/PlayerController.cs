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

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        energy.CanIncrease = !Input.GetButton("Sprint");
    }

    void Move()
    {
        //Move faster diagonally
        var y = body.transform.forward * Input.GetAxis("Vertical") * stats.Speed * Time.fixedDeltaTime;
        var x = body.transform.right * Input.GetAxis("Horizontal") * stats.Speed * Time.fixedDeltaTime;
        var translation = y + x;

        if (Input.GetButton("Sprint") && energy.CanPerformAction(PlayerStatsSO.PlayerAction.SPRINT)
            && translation != Vector3.zero)
        {
            energy.PerformAction(PlayerStatsSO.PlayerAction.SPRINT);
            translation *= stats.SprintMultiplier;
        }

        body.MovePosition(translation + transform.position);
    }
}
