using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PlayerReset"))
        {
            playerTransform.localEulerAngles = new Vector3(0, playerTransform.localEulerAngles.y, 0);
        }
    }
}
