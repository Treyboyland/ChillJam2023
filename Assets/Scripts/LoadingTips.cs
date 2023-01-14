using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingTips : MonoBehaviour
{
    [SerializeField]
    TextListSO textList;

    [SerializeField]
    TMP_Text textBox;

    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = UnityEngine.Random.Range(0, textList.Text.Count);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Left"))
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = textList.Text.Count - 1;
            }
            UpdateText();
        }
        else if (Input.GetButtonDown("Right"))
        {
            currentIndex = (currentIndex + 1) % textList.Text.Count;
            UpdateText();
        }
    }

    void UpdateText()
    {
        textBox.text = textList.Text[currentIndex];
    }
}
