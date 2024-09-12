using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField, Tooltip("��������� ������")] float StartRadius;
    [SerializeField, Tooltip("�������� ������")] float EndRadius;
    [SerializeField, Tooltip("�������� ��������� �������")] float RadiusChangerSpeed;

    [SerializeField, Tooltip("��������� ����")] float StartAngle;
    [SerializeField, Tooltip("�������� ����")] float EndAngle;
    [SerializeField, Tooltip("�������� ��������� �����")] float AngleChangerSpeed;

    [SerializeField] ParticleSystem PSModule;
    [SerializeField] float currentRadius;
    [SerializeField] float currentAngle;
    // Start is called before the first frame update
    void Start()
    {
        currentRadius = StartRadius;
        currentAngle = StartAngle;
    }

    // Update is called once per frame
    void Update()
    {
        currentRadius = Mathf.Lerp(StartRadius, EndRadius, Mathf.PingPong(Time.time * RadiusChangerSpeed, 1));
        currentAngle = Mathf.Lerp(StartAngle, EndAngle, Mathf.PingPong(Time.time * AngleChangerSpeed, 1));
        var shape = PSModule.shape;
        shape.radius = currentRadius;
        shape.angle = currentAngle;
    }
}
