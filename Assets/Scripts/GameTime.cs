using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameTime : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    float gameTimeSeconds;

    float elapsed = 0;

    bool eventFired = false;

    bool canAddTime = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnGameWin.AddListener(() => canAddTime = false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canAddTime)
        {
            elapsed += Time.deltaTime;
        }

        if (elapsed < gameTimeSeconds)
        {
            SetTimeFloat(gameTimeSeconds - elapsed);
        }
        else if (!eventFired)
        {
            eventFired = true;
            SetTimeFloat(0);
            GameManager.Manager.OnGameLoss.Invoke(GameOverHandler.GameOverReason.TIME_UP);
        }
    }

    void SetTimeFloat(float time)
    {
        int milliseconds = (int)((time % 1) * 1000);
        TimeSpan timeSpan = new TimeSpan(0, 0, 0, (int)time, milliseconds);

        if (timeSpan.TotalSeconds < 10)
        {
            textBox.text = "Time: " + timeSpan.ToString(@"ss\.f");
        }
        else
        {
            textBox.text = "Time: " + timeSpan.ToString(@"m\:ss");
        }

    }
}
