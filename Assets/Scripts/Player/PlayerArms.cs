using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArms : MonoBehaviour
{
    [SerializeField]
    PlayerEnergy energy;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        energy.OnActionPerformed.AddListener(FlipArms);
    }

    void FlipArms(PlayerStatsSO.PlayerAction action)
    {
        if (action == PlayerStatsSO.PlayerAction.FLIP)
        {
            animator.SetTrigger("Flip");
        }
    }
}
