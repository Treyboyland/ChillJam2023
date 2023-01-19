using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConeController : MonoBehaviour
{
    [SerializeField]
    GameObject cone;

    public GameObject Cone { get => cone; }

    // Start is called before the first frame update
    void Start()
    {
        cone.gameObject.SetActive(false);
        GameManager.Manager.OnSpawnCone.AddListener(pos =>
        {
            cone.transform.position = new Vector3(pos.x, 0, pos.z);
            cone.gameObject.SetActive(true);
        });
    }
}
