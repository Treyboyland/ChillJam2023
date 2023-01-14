using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMover : MonoBehaviour
{
    [SerializeField]
    Rigidbody body;

    [SerializeField]
    Cow cow;

    [SerializeField]
    Animator animator;

    [SerializeField]
    CowRandomizer randomizer;

    bool walkFirst;

    // Start is called before the first frame update
    void Start()
    {
        walkFirst = Random.Range(0.0f, 1.0f) < .5;
        StartCoroutine(WalkCycle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CowWait(float seconds)
    {
        float elapsed = 0;
        while (elapsed < seconds)
        {
            if (cow.FlippedOnce)
            {
                yield break;
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Walk()
    {
        transform.localEulerAngles = new Vector3(0, randomizer.RotationWalk, 0);
        animator.SetBool("Walking", true);
        float walkSpeed = randomizer.WalkSpeed;
        float elapsed = 0;
        float seconds = randomizer.WalkTime;
        while (elapsed < seconds)
        {
            elapsed += Time.deltaTime;
            body.MovePosition(transform.position + transform.forward * walkSpeed * Time.fixedDeltaTime);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        animator.SetBool("Walking", false);
    }

    IEnumerator WalkCycle()
    {
        while (true)
        {
            if (cow.IsWinner || cow.FlippedOnce)
            {
                animator.SetBool("Walking", false);
                yield break;
            }
            if (!walkFirst)
            {
                yield return StartCoroutine(CowWait(randomizer.WaitTimeWalk));
            }
            yield return StartCoroutine(Walk());
        }

    }
}
