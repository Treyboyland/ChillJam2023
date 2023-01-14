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

    public bool ShouldStop = false;

    // Start is called before the first frame update
    void Start()
    {
        walkFirst = Random.Range(0.0f, 1.0f) < .5;
        StartCoroutine(WalkCycle());
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
        animator.SetBool("Walk", true);
        float walkSpeed = randomizer.WalkSpeed;
        float elapsed = 0;
        float seconds = randomizer.WalkTime;
        Vector3 forward = transform.forward;
        body.velocity = forward * walkSpeed;
        while (elapsed < seconds)
        {
            if (cow.FlippedOnce)
            {
                yield break;
            }
            if (ShouldStop)
            {
                break;
            }
            body.angularVelocity = Vector3.zero;
            body.velocity = forward * walkSpeed;
            elapsed += Time.deltaTime;

            //var pos = transform.position + forward * walkSpeed * Time.fixedDeltaTime;
            //pos.y = transform.position.y;

            //body.MovePosition(pos);
            //body.AddRelativeForce(transform.forward * walkSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
            yield return null;
        }

        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;
        animator.SetBool("Walk", false);
    }

    IEnumerator WalkCycle()
    {
        while (true)
        {
            if (cow.IsWinner || cow.FlippedOnce)
            {
                animator.SetBool("Walk", false);
                if (cow.FlippedOnce)
                {
                    animator.SetBool("Flail", true);
                }
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
