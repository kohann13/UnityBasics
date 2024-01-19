using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private float SensX;
    [SerializeField] private float SensY;

    private float XRotation;
    private float YRotation;

    [SerializeField] private Transform Orientation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        YRotation += MouseX;
        XRotation -= MouseY;

        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0f);
        Orientation.rotation = Quaternion.Euler(0f, YRotation, 0f);
    }
}
