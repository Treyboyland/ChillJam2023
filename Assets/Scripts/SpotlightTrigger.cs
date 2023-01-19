using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightTrigger : MonoBehaviour
{
    [SerializeField]
    SpotlightGame spotlight;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerLives>();
        if (player)
        {
            spotlight.Light.color = spotlight.BadColor;
            spotlight.OnPlayerDetected.Invoke();
            //Bad sound?
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerLives>();
        if (player)
        {
            spotlight.Light.color = spotlight.NormalColor;
        }
    }
}
