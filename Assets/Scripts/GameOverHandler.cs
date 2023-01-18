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
                textBox.text = "Out of Lives!";
                break;
            case GameOverReason.TIME_UP:
                textBox.text = "Time's up!";
                break;
            case GameOverReason.SUSPICION_MAXED:
                textBox.text = "You got caught!";
                break;
            default:
                textBox.text = "You lost!";
                break;
        }
    }
}
