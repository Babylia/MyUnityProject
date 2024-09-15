using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BasicCharacterBehavior : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [Header("Характеристики")]
    [SerializeField] protected int MaxHealth;
    [SerializeField] protected int MaxStamina;
    [SerializeField] protected int MaxMana;
    [SerializeField] protected int Armor;
    [SerializeField] protected float WalkSpeed;
    [SerializeField] protected float RunSpeed;
    [SerializeField] protected float JumpForce;
    [SerializeField] protected int Damage;
    [Header("Атрибуты")]
    [SerializeField] protected int Agility;
    [SerializeField] protected int Strength;
    [SerializeField] protected int intelligence; 
    [Header("Текущее значения")]
    [SerializeField] protected int Health;
    [SerializeField] protected int Stamina;
    [SerializeField] protected int Mana;
    [SerializeField] protected float Speed;
    [SerializeField] protected bool IsOnBlock;
    [Header("Инвентарь"), SerializeField] public Dictionary<GameObject, int> Inventory;

    // Start is called before the first frame update
    void Start()
    {
        IsOnBlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Attack() { }
    public void Jump() 
    {
        if (IsOnBlock)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnBlock = false;
        }
    }

    public void TakeDamage(int damage) { Health -= damage*((100-Armor)/100); }
    public void Die() { Destroy(gameObject); }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            IsOnBlock = true;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            IsOnBlock = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            IsOnBlock = false;
        }
    }
}
