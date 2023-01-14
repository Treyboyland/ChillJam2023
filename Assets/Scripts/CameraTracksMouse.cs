using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracksMouse : MonoBehaviour
{
    [SerializeField]
    Camera cameraToUse;

    [SerializeField]
    Vector2 sensitivity;

    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
        //Debug.LogWarning("Mouse Pos: " + mousePos);
        //var worldPos = cameraToUse.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, .1f));

    }

    void UpdateCamera()
    {
        var mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        pitch -= mousePos.y * sensitivity.y;

        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

        cameraToUse.transform.localEulerAngles = Vector3.right * pitch;

        transform.Rotate(Vector3.up * mousePos.x * sensitivity.x);
    }
}
