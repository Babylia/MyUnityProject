using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVision : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] float VisionRadius;
    [SerializeField] LayerMask BarrierLayer;
    [SerializeField] Transform ClosestBarrier;
    [SerializeField] bool IsHiding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(IsHiding)
            {
                Unhide();
            }
            else
            {
                Hide();
            }
        }
    }
    void Hide()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, VisionRadius, BarrierLayer);
        if(hitColliders.Length > 0 )
        {
            ClosestBarrier = null;
            float MinimalDistance = Mathf.Infinity;
            foreach(Collider item in hitColliders)
            {
                float Distance = Vector3.Distance(transform.position, item.transform.position);
                if (Distance < MinimalDistance)
                {
                    MinimalDistance = Distance;
                    ClosestBarrier=item.transform;
                }
            }
            if (ClosestBarrier != null)
            {
                Vector3 directionToBarrier = ClosestBarrier.position - transform.position;

                float leftDistance = Vector3.Distance(ClosestBarrier.position + ClosestBarrier.right * (ClosestBarrier.localScale.z / 2), transform.position);
                float rightDistance = Vector3.Distance(ClosestBarrier.position - ClosestBarrier.right * (ClosestBarrier.localScale.z / 2), transform.position);

                if (leftDistance < rightDistance)
                {
                    transform.position = ClosestBarrier.position - ClosestBarrier.right * (ClosestBarrier.localScale.z / 2 + transform.localScale.z / 2);
                }
                else
                {
                    transform.position = ClosestBarrier.position + ClosestBarrier.right * (ClosestBarrier.localScale.z / 2 + transform.localScale.z / 2);
                }
            }
        }
        else
        {

        }
    }

    void Unhide()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,VisionRadius);
    }
}
