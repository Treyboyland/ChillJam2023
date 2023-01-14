using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}
