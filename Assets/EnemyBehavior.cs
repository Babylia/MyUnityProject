using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] AnimationCurve MoveAnimation;
    [SerializeField] float Duration;
    [SerializeField] float Distance;
    [SerializeField] float TimeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeElapsed < Distance)
        {
            TimeElapsed += Time.deltaTime;
            float Result=TimeElapsed/Distance;
            float CurrentPos=MoveAnimation.Evaluate(Result);
            transform.position += Vector3.forward*Time.deltaTime*CurrentPos;
        }
        else
        {
            TimeElapsed = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            collision.gameObject.GetComponent<CharacterStatsBehavior>().Health -= 30;
        }
    }
}
