using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem PS;
    [SerializeField] float BaseSpeed;
    [SerializeField] float MaxSpeed;
    [SerializeField] float SpeedChangeDuration;
    [SerializeField] float currentSpeed;
    [SerializeField] float speedChangerTime;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = BaseSpeed;
        speedChangerTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartParticle()
    {
        if (speedChangerTime< SpeedChangeDuration)
        {
            speedChangerTime += Time.deltaTime;
            currentSpeed = Mathf.Lerp(BaseSpeed,MaxSpeed,speedChangerTime/SpeedChangeDuration);
        }
        var mainModule = PS.main;
        mainModule.startSpeed = currentSpeed;
    }
}
