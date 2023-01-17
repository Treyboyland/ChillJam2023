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
            //Bad sound?
            player.TakeDamage();
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
