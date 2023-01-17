using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnAnimationState : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    string state;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(state))
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
