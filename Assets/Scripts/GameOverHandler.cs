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
        TIME_UP
    }


    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        GameManager.Manager.OnGameLoss.AddListener(SetGameOverText);
    }

    void SetGameOverText(GameOverReason reason)
    {
        switch (reason)
        {
            case GameOverReason.NO_LIVES:
                textBox.text = "Out of Lives!";
                break;
            case GameOverReason.TIME_UP:
                textBox.text = "Time's up!";
                break;
            default:
                textBox.text = "You lost!";
                break;
        }
    }
}
