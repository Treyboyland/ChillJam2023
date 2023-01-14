using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCowFlipper : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        var cow = other.gameObject.GetComponent<Cow>();
        if (cow)
        {
            cow.FlipCow();
        }
    }
}
