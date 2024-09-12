using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField, Tooltip("Начальный радиус")] float StartRadius;
    [SerializeField, Tooltip("Конечный радиус")] float EndRadius;
    [SerializeField, Tooltip("Скорость изменения радиуса")] float RadiusChangerSpeed;

    [SerializeField, Tooltip("Начальный угол")] float StartAngle;
    [SerializeField, Tooltip("Конечный угол")] float EndAngle;
    [SerializeField, Tooltip("Скорость изменения угола")] float AngleChangerSpeed;

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
