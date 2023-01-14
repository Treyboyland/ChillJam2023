using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLivesUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    PlayerLives lives;

    int currentLives = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives != lives.CurrentHealth)
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        currentLives = lives.CurrentHealth;
        text.text = "Lives: " + lives.CurrentHealth;
    }
}
