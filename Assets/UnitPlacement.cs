using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacement : MonoBehaviour
{
    [SerializeField] GameObject UnitPref;
    [SerializeField] GameObject GhostPref;
    [SerializeField] bool IsUnitSelected;

    public void StartUnitPlacing()
    {
        if(GhostPref!= null)
        {
            Destroy(GhostPref);
        }
        GhostPref=Instantiate(UnitPref);
        IsUnitSelected = true;
    }
    void MoveUnitToMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit) )
        {
            Vector3 alignedPos = new Vector3(Mathf.Round(hit.point.x),
                                             Mathf.Round(hit.point.y),
                                             Mathf.Round(hit.point.z));
            GhostPref.transform.position = alignedPos; 
        }
    }
    void PlaceUnit()
    {
        Instantiate(UnitPref,GhostPref.transform.position,Quaternion.identity);
        GhostPref = null;
        IsUnitSelected = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsUnitSelected &&GhostPref!=null)
        {
            MoveUnitToMousePoint();
            if(Input.GetMouseButtonDown(0))
            {
                PlaceUnit();
            }
        }
    }
}
