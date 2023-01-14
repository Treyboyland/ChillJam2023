using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowWinParticle : MonoBehaviour
{
    [SerializeField]
    Cow cow;

    [SerializeField]
    GameObject winParticle;
    
    // Update is called once per frame
    void Update()
    {
        winParticle.gameObject.SetActive(cow.IsWinner);
    }
}
