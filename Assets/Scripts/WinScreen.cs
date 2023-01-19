using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    Animator fadeout;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    List<GameObject> otherObjects;

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        foreach (var obj in otherObjects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public void StartWinSequence()
    {
        canvas.gameObject.SetActive(true);
        StartCoroutine(DoWinStuff());
    }

    IEnumerator DoWinStuff()
    {
        while (!fadeout.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            yield return null;
        }
        foreach (var obj in otherObjects)
        {
            obj.gameObject.SetActive(true);
        }
    }
}
