using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [Header("Стрельба"), SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField] Transform ProjectileSpawner;
    [SerializeField] float ProjectileSpeed;
    [Header("Граната"), SerializeField] GameObject GranadePref;
    [SerializeField] GameObject GranadeSpawner;
    [SerializeField] float GranadeSpeed;
    
    void Fire()
    {
            GameObject Tprojectile = Instantiate(ProjectilePrefab, ProjectileSpawner.position, transform.rotation);
            Tprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileSpeed * Time.deltaTime, ForceMode.Impulse);     
    }
    void ThrowGranade()
    {
        Instantiate(GranadePref, transform.position, Quaternion.identity);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGranade();
        }
    }
}
