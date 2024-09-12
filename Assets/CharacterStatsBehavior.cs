using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStatsBehavior : MonoBehaviour
{
    [Header("Здоровье"), SerializeField, Range(0, 100)]
    int health;
    [Header("Выносливость"), SerializeField, Range(0, 100)]
    float stamina;


    public int Health
    {
        get { return health; }
        set
        {
            if (value >= 0 && value <= 100)
            {
                health = value;
            }
            else if (value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public float Stamina
    {
        get { return stamina; }
        set
        {
            if (value >= 0 && value <= 100)
            {
                stamina = value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Stamina+=0.01f;
    }
}
