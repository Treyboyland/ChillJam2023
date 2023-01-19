using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    TextListSO tutorialText;

    [SerializeField]
    string sceneToLoad;

    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    public void Next()
    {
        currentIndex++;
        if (currentIndex >= tutorialText.Text.Count)
        {
            LoadScene();
        }

        SetText();
    }

    void SetText()
    {
        textBox.text = tutorialText.Text[currentIndex];
    }

    public void Previous()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = 0;
        }

        SetText();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
