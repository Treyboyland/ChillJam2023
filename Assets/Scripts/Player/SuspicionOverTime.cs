using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionOverTime : MonoBehaviour
{
    [SerializeField]
    FloatValue suspicionDamage;

    PlayerSuspicion currentSuspicion;

    private void Update()
    {
        if (currentSuspicion)
        {
            currentSuspicion.CurrentSuspicion += suspicionDamage.Value * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerSuspicion suspicion = other.gameObject.GetComponent<PlayerSuspicion>();
        if (suspicion)
        {
            currentSuspicion = suspicion;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerSuspicion suspicion = other.gameObject.GetComponent<PlayerSuspicion>();
        if (suspicion == currentSuspicion)
        {
            currentSuspicion = null;
        }
    }

}
