using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEverything : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Reset to safe position
        other.transform.position = new Vector3(0, 10, 0);
    }
}
