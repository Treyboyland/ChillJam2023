using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    BombStatsSO stats;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody body;

    const string ANIMATE_TRIGGER = "Detonate";

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector3 GetAngularVelocity()
    {
        Vector2 rand = new Vector2(-1, 1);
        return new Vector3(rand.Random(), rand.Random(), rand.Random());
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            body.angularVelocity = GetAngularVelocity();
            StartCoroutine(StartDetonation());
        }
    }

    IEnumerator StartDetonation()
    {
        animator.SetBool(ANIMATE_TRIGGER, false);
        yield return new WaitForSeconds(stats.SecondsBeforeFast);
        animator.SetBool(ANIMATE_TRIGGER, true);
        yield return new WaitForSeconds(stats.SecondsBeforeExplosion);
        GameManager.Manager.OnSpawnExplosion.Invoke(transform.position);
        gameObject.SetActive(false);
    }
}
