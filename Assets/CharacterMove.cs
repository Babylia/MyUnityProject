using System;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class CharacterMove : MonoBehaviour
{
    [Header("Физика"), SerializeField]
    Rigidbody rb;

    [Header("Параметры")]
    private float MoveSpeed;

    [SerializeField, Range(5, 20)] float RunSpeed;
    [SerializeField, Range(0, 10)] float WalkSpeed;

    [SerializeField,Range(0,30)]float reduceStaminaSpeed;

    [SerializeField, Range(0, 10)]
    private float JumpForce;

    [SerializeField, Range(0, 100)]
    private float RotateSpeed;

    [ContextMenu("Метод движения")]
    void Move()
    {
        float Direction = Input.GetAxis("Vertical");
        Vector3 Movement = transform.forward * Direction * MoveSpeed * Time.deltaTime;
        Vector3 NewPos = rb.position + Movement;
        rb.MovePosition(NewPos);
    }

    [ContextMenu("Метод поворота")]
    void Rotate()
    {
        float Direction = Input.GetAxis("Horizontal");
        Quaternion Rotation = Quaternion.AngleAxis(Direction * RotateSpeed * Time.deltaTime, Vector3.up);
        rb.MoveRotation(Rotation * rb.rotation);
    }

    void ChangeSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && transform.GetComponent<CharacterStatsBehavior>().Stamina > 0.1f)
        {
            MoveSpeed = RunSpeed;
            transform.GetComponent<CharacterStatsBehavior>().Stamina -= reduceStaminaSpeed*Time.deltaTime;
            if (transform.GetComponent<CharacterStatsBehavior>().Stamina <=0.1f)
            {
                MoveSpeed = WalkSpeed;
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = WalkSpeed;
        }

    }
    void Start()
    {
        MoveSpeed = WalkSpeed;
    }

    void Update()
    {
        Move();
        Rotate();
        ChangeSpeed();
    }
    //void QuaternionRotate()
    //{
    //    Quaternion rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationAxis);
    //    transform.rotation = rotation * transform.rotation;
    //}
}
