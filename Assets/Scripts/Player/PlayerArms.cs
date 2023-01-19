using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArms : MonoBehaviour
{
    [SerializeField]
    PlayerEnergy energy;

    [SerializeField]
    List<Animator> animators;

    // Start is called before the first frame update
    void Start()
    {
        energy.OnActionPerformed.AddListener(FlipArms);
    }

    void FlipArms(PlayerStatsSO.PlayerAction action)
    {
        if (action == PlayerStatsSO.PlayerAction.FLIP)
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger("Flip");
            }
        }
    }
}
