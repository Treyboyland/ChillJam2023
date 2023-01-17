using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    [SerializeField]
    bool singleUse;

    bool usedOnce = false;

    private void OnEnable()
    {
        usedOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerLives lives = other.gameObject.GetComponent<PlayerLives>();
        if (lives && ((singleUse && !usedOnce) || !singleUse))
        {
            usedOnce = true;
            lives.TakeDamage();
        }
    }
}
