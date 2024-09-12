using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public enum RotationMethods
    {
        TransformRotate,
        EulerAngles,
        Quaternion
    }

    public RotationMethods RotationMethod = RotationMethods.TransformRotate;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed;


    private void Update()
    {
        switch (RotationMethod)
        {
            case RotationMethods.TransformRotate:
                {
                    TransformRotate();
                    break;
                }
            case RotationMethods.EulerAngles:
                {
                    EualerRotate();
                    break;
                }
            case RotationMethods.Quaternion:
                {
                    QuaternionRotate();
                    break;
                }
        }
    }

    void TransformRotate()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    void EualerRotate()
    {
        Vector3 euler = transform.eulerAngles;
        euler += rotationAxis * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = euler;
    }

    void QuaternionRotate()
    {
        Quaternion rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationAxis);
        transform.rotation = rotation * transform.rotation;
    }
}