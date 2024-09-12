using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehavior : MonoBehaviour
{
    [SerializeField] float ExplosionDelay;
    [SerializeField] float ExplosionRadius;
    [SerializeField] int Damage;
    [SerializeField] LayerMask DamagableLayer;
    [SerializeField] AnimationCurve GrenadeTrajectory;
    [SerializeField] Vector3 TargetPos;
    [SerializeField] Vector3 InitPos;
    [SerializeField] float ElapsedTime;
    [SerializeField] float ThrowDistance;
    [SerializeField] Rigidbody rb;
    [SerializeField] float ForceOfthrow;
    // Start is called before the first frame update
    void Start()
    {
        InitPos = transform.position;
        Invoke(nameof(Explode),ExplosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        AnimThrow();
    }
    void AnimThrow()
    {
        if (ElapsedTime < ThrowDistance)
        {
            ElapsedTime += Time.deltaTime;
            float progress = ElapsedTime / ThrowDistance;
            float currentValue = GrenadeTrajectory.Evaluate(progress);
            Vector3 NewPos = transform.position + Vector3.up * Time.deltaTime * currentValue*ForceOfthrow;
            rb.MovePosition(NewPos);
        }
        else
        {
            ElapsedTime = 0;
        }
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,ExplosionRadius,DamagableLayer);
        foreach (Collider collider in colliders)
        {
            collider.GetComponent<CharacterStatsBehavior>().Health -= Damage;
        }
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,ExplosionRadius);
    }
}
