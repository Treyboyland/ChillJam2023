using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowStopper : MonoBehaviour
{
    [SerializeField]
    CowMover mover;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Stop cow from colliding with other cows
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (!player)
        {
            mover.ShouldStop = true;
        }
    }
}
