using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeExample : MonoBehaviour
{
    [SerializeField] AnimationCurve MoveCurve;
    [SerializeField] float Duration;
    [SerializeField] float Distance;
    [SerializeField] float elapsedTime;
    Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AnimCurveMove();
    }
    void AnimCurveMove()
    {
        if (elapsedTime < Duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / Duration;
            float currentValue = MoveCurve.Evaluate(progress);
            float newY = StartPos.y + currentValue* Distance; 
            transform.position = new Vector3(transform.position.x,newY,transform.position.z);
        }
        else
        {
            elapsedTime = 0;
        }
    } 
}
