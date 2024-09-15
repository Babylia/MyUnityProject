using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerCharacterBehavior : BasicCharacterBehavior
{
    [Header("”правление"), SerializeField] Vector3 MoveDir;
    [SerializeField] float Sensivity;
    [SerializeField] Vector2 CameraRotation;
    [SerializeField] float yRotationLimit;
    [SerializeField] Transform Camera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void PlayerMove()
    {
        MoveDir.x = Input.GetAxis("Horizontal");
        MoveDir.z = Input.GetAxis("Vertical");
        Vector3 NewPos = (transform.forward * MoveDir.z + transform.right * MoveDir.x)*Speed*Time.deltaTime;
        rb.MovePosition(rb.position+NewPos);
    }

    void CameraBehavior()
    {
        CameraRotation.x += Input.GetAxis("Mouse X") * Sensivity;
        CameraRotation.y += Input.GetAxis("Mouse Y") * Sensivity;
        CameraRotation.y = Mathf.Clamp(CameraRotation.y, -yRotationLimit, yRotationLimit);
        Quaternion xQuat = Quaternion.AngleAxis(CameraRotation.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(CameraRotation.y, Vector3.left);
        transform.localRotation = xQuat;
        Camera.localRotation = yQuat;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CameraBehavior();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

}
