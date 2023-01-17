using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    [SerializeField]
    Rigidbody body;

    [SerializeField]
    List<MeshRenderer> renderers;

    [SerializeField]
    CowRandomizer randomizer;

    [SerializeField]
    OneShotAudio mooAudio;

    public bool CanFlip { get; set; } = false;

    public bool FlippedOnce { get; set; } = false;

    Vector3 tipVelocity;

    public Vector3 TipVelocity { get => tipVelocity; }

    float angularMultiple;

    static PlayerController player;
    static PlayerEnergy tipper;

    public bool IsWinner { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = GameObject.FindObjectOfType<PlayerController>();
            if (player != null)
            {
                tipper = player.GetComponentInChildren<PlayerEnergy>();
            }

        }
    }

    private void OnEnable()
    {
        RandomizeSettings();
    }

    void RandomizeSettings()
    {
        transform.localScale = randomizer.Size;
        angularMultiple = randomizer.AngularMultiplier;
        body.mass = randomizer.Mass;
        var material = randomizer.Material;

        foreach (var renderer in renderers)
        {
            //Memory leak?
            renderer.material = material;
        }

        float y = Random.Range(0.0f, 360f);
        transform.localEulerAngles = new Vector3(0, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckFlipCow();
    }

    private void OnTriggerEnter(Collider other)
    {
        var trigger = other.gameObject.GetComponent<CowTipper>();
        if (trigger)
        {
            CanFlip = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var trigger = other.gameObject.GetComponent<CowTipper>();
        if (trigger)
        {
            CanFlip = false;
        }
    }

    void CheckFlipCow()
    {
        if (Input.GetButtonDown("Flip") && CanFlip && tipper != null && tipper.CanPerformActions &&
            tipper.CanPerformAction(PlayerStatsSO.PlayerAction.FLIP))
        {
            tipper.PerformAction(PlayerStatsSO.PlayerAction.FLIP);
            FlipCow();
        }
    }

    public void FlipCow()
    {
        FlippedOnce = true;
        body.velocity = randomizer.FlipVelocity;
        Vector3 angularNorm;
        if (player == null)
        {
            angularNorm = Random.onUnitSphere;
        }
        else
        {
            angularNorm = (player.transform.position - transform.position).normalized;
            if (IsWinner)
            {
                //TODO: Rotate Over, don't flip to sky
                //Metallic sound
                body.velocity = Vector3.zero;
                //GameManager.Manager.OnGameWin.Invoke();
            }
        }

        if (mooAudio && !IsWinner)
        {
            mooAudio.gameObject.SetActive(true);
        }

        body.angularVelocity = angularNorm * angularMultiple;

        if (!IsWinner && randomizer.ShouldSpawnBomb)
        {
            StartCoroutine(BombDelay());
        }
    }

    IEnumerator BombDelay()
    {
        yield return new WaitForSeconds(randomizer.SecondsToWaitBeforeBomb);
        GameManager.Manager.OnSpawnBomb.Invoke(transform.position);
    }
}
