using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ScreenshotTaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    string GetDateAsString()
    {
        return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
    }

    private void Update()
    {
        OnScreenshot();
    }

    // Update is called once per frame
    void OnScreenshot()
    {
        bool pressed = Input.GetButtonDown("Screenshot");
        if (pressed)
        {
            string directory = Application.dataPath + "/../Screenshots";
            try
            {
                if (!Directory.Exists(directory))
                {

                    Directory.CreateDirectory(directory);
                }
                string filename = directory + "/Screenshot-" + GetDateAsString() + ".png";
                Debug.LogWarning(filename);
                ScreenCapture.CaptureScreenshot(filename);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

}
