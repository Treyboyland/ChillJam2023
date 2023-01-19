using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionIncreaseBurst : MonoBehaviour
{
    [SerializeField]
    FloatValue suspicionDamage;

    [SerializeField]
    bool singleUse;

    bool usedOnce = false;

    private void OnDisable()
    {
        usedOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerSuspicion lives = other.gameObject.GetComponent<PlayerSuspicion>();
        if (lives && !lives.Invincible && ((singleUse && !usedOnce) || !singleUse))
        {
            usedOnce = true;
            lives.CurrentSuspicion += suspicionDamage.Value;
        }
    }
}
