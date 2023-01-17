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

    bool waitFirst;

    public bool ShouldStop = false;

    // Start is called before the first frame update
    void Start()
    {
        waitFirst = Random.Range(0.0f, 1.0f) < .5;
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
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Walk()
    {
        float angle = randomizer.RotationWalk;
        transform.localEulerAngles = new Vector3(0, angle, 0);

        float startingY = transform.position.y;
        animator.SetBool("Walk", true);
        float walkSpeed = randomizer.WalkSpeed;
        float elapsed = 0;
        float seconds = randomizer.WalkTime;
        Vector3 forward = transform.forward;
        body.velocity = forward * walkSpeed;
        bool flip = false;
        while (elapsed < seconds)
        {
            if (cow.FlippedOnce)
            {
                yield break;
            }
            if (ShouldStop)
            {
                //Flip velocity vector...
                flip = !flip;
                ShouldStop = false;
            }
            var pos = transform.position;
            pos.y = startingY;
            transform.position = pos;

            body.angularVelocity = Vector3.zero;
            body.velocity = forward * walkSpeed * (flip ? -1 : 1);
            transform.localEulerAngles = new Vector3(0, flip ? angle + 180 : angle, 0);

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
            if (waitFirst)
            {
                yield return StartCoroutine(CowWait(randomizer.WaitTimeWalk));
            }
            else
            {
                waitFirst = true;
            }
            if (!cow.FlippedOnce)
            {
                yield return StartCoroutine(Walk());
            }
        }

    }
}
