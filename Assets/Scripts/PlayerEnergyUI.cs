using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyUI : MonoBehaviour
{
    [SerializeField]
    PlayerEnergy energy;

    [SerializeField]
    Image energyImage;


    // Update is called once per frame
    void Update()
    {
        energyImage.fillAmount = energy.Percentage;
    }
}
