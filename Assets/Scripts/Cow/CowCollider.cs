using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowCollider : MonoBehaviour
{
    [SerializeField]
    OneShotAudio tink;

    private void OnTriggerEnter(Collider other)
    {
        var cow = other.gameObject.GetComponent<Cow>();
        Debug.LogWarning("Hit");

        if (cow && cow.IsWinner)
        {
            tink.gameObject.SetActive(true);
        }
    }
}
