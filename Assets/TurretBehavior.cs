using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    [Header("Игрок"), SerializeField]
    Transform Player;
    [SerializeField]
    LayerMask PlayerLayer;
    bool IsPlayerInSight;
    [Header("Снаряд"), SerializeField]
    GameObject ProjectilePrefab;
    [SerializeField] Transform ProjectileSpawner;
    [SerializeField]
    float ProjectileSpeed;
    [Header("Параметры"), SerializeField]
    float DistanceToView;
    [SerializeField]
    float Frequency;
    [SerializeField]
    float Amplitude;
    [SerializeField] float fireCooldown;
    float Firetimer;
    float time = 0;
    [SerializeField] Quaternion InitialRotation;
    // Start is called before the first frame update
    void Start()
    {
        InitialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
        if (IsPlayerInSight)
        {
            RotateToPlayer();
            Fire();
        }
        else
        {
            Movement();
        }
        Firetimer += Time.deltaTime;
    }
    void CheckPlayer()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, DistanceToView, PlayerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                IsPlayerInSight = true;
            }
        }
        else
        {
            IsPlayerInSight = false;
        }
    }
    void Movement()
    {
        time += Time.deltaTime;
        float yRotation= Mathf.Sin(time * Frequency) * Amplitude;
        Quaternion rotation = Quaternion.Euler(0, yRotation, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation,InitialRotation*rotation,Frequency*Time.deltaTime);
    }
    void RotateToPlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(Player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * Frequency);
    }
    void Fire()
    {
        if (Firetimer >= fireCooldown)
        {
            Vector3 Direction = Player.position - transform.position;
            GameObject Tprojectile = Instantiate(ProjectilePrefab, ProjectileSpawner.position, transform.rotation);
            Tprojectile.GetComponent<Rigidbody>().AddForce(Direction * ProjectileSpeed * Time.deltaTime, ForceMode.Impulse);
            Firetimer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = IsPlayerInSight ? Color.red : Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * DistanceToView);
    }
}
