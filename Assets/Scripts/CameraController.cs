using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    public float sensitibleMouseX = 0.5f;
    public float sensitibleMouseY = 0.5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    //float smoothCoefx = 0.005f;
    //float smoothCoefy = 0.005f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    void Update()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitibleMouseY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitibleMouseX;

        //smoothCoefx = Mathf.Lerp(smoothCoefx, horizontalDelta, smoothCoefx);
        //smoothCoefy = Mathf.Lerp(smoothCoefy, verticalDelta, smoothCoefy);

        rotationX += horizontalDelta;
        rotationY += verticalDelta;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);
        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);
        transform.localEulerAngles = new Vector3(-rotationY, rotationY, 0);
    }
}
