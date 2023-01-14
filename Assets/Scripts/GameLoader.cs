using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;

    [SerializeField]
    float secondsToWait;

    [SerializeField]
    TMP_Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "";
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        var load = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);
        load.allowSceneActivation = false;


        while (load.progress < .9f)
        {
            yield return null;
        }

        textBox.text = "Click to Continue...";
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                load.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
