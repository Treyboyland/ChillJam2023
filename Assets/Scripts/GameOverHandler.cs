using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverCanvas;

    [SerializeField]
    TMP_Text textBox;

    public enum GameOverReason
    {
        NO_LIVES,
        TIME_UP,
        SUSPICION_MAXED
    }


    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        GameManager.Manager.OnGameLoss.AddListener(SetGameOverText);
    }

    void SetGameOverText(GameOverReason reason)
    {
        gameOverCanvas.gameObject.SetActive(true);
        switch (reason)
        {
            case GameOverReason.NO_LIVES:
                textBox.text = "What did you do?!";
                break;
            case GameOverReason.TIME_UP:
                textBox.text = "Alright, time's up! I won’t tell them we didn't find it if you don't.";
                break;
            case GameOverReason.SUSPICION_MAXED:
                textBox.text = "What are you doing out there? I've got corporate on my back telling me all the humans are going crazy! Let's get out of here and move on to the next site.";
                break;
            default:
                textBox.text = "You lost!";
                break;
        }
    }
}
