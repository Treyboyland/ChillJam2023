using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinManager : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;

    [SerializeField]
    PlayerSuspicion suspicion;

    [SerializeField]
    CowSpawner spawner;

    [SerializeField]
    AudioSource alienSound;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float secondsToWait;

    [SerializeField]
    WinScreen winScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnGameWin.AddListener(DowWinStuff);
    }

    void DowWinStuff()
    {
        suspicion.Invincible = true;
        controller.CanMove = false;
        var cow = spawner.GetWinningCow();
        StartCoroutine(RaiseBoth(cow));
        StartCoroutine(WaitThenWin());
    }

    IEnumerator WaitThenWin()
    {
        yield return new WaitForSeconds(secondsToWait);
        winScreen.StartWinSequence();
    }

    IEnumerator RaiseBoth(Cow cow)
    {
        alienSound.Play();
        Rigidbody cowBody = null, playerBody;
        if (cow)
        {
            cowBody = cow.GetComponent<Rigidbody>();
            cowBody.isKinematic = true;
            cowBody.velocity = Vector3.zero;
            cowBody.angularVelocity = Vector3.zero;
        }
        playerBody = controller.GetComponent<Rigidbody>();
        playerBody.isKinematic = true;
        playerBody.velocity = Vector3.zero;
        playerBody.angularVelocity = Vector3.zero;
        playerBody.transform.SetParent(cowBody.transform);

        while (true)
        {
            var movementVector = Vector3.up * movementSpeed * Time.fixedDeltaTime;
            if (cowBody)
            {
                cowBody.MovePosition(cowBody.transform.position + movementVector);
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
