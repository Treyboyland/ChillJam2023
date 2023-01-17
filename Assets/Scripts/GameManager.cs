using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    string winScene;

    public UnityEvent OnGameWin;
    public UnityEvent<GameOverHandler.GameOverReason> OnGameLoss;
    public UnityEvent OnPlayMoo;

    public UnityEvent<Vector3> OnSpawnBomb;
    public UnityEvent<Vector3> OnSpawnExplosion;

    public UnityEvent<bool> OnPlayerSprint;

    static GameManager _instance;

    public static GameManager Manager { get => _instance; }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        OnGameWin.AddListener(LoadWinScreen);
    }

    void LoadWinScreen()
    {
        SceneManager.LoadScene(winScene, LoadSceneMode.Single);
    }
}
