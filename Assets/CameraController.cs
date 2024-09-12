using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("Параметры камеры")]
    [SerializeField]
    float minDist;
    [SerializeField]
    float maxDist;
    [SerializeField]
    float ZoomField;
    [SerializeField]
    CinemachineFreeLook CinemachineFreeLook;
    [SerializeField] Canvas Testwindow;
    [Header("бары"), SerializeField]
    Slider HealthSlider;
    [SerializeField] Slider StaminaBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
        BarsUpdate();
        TestWindow();

    }
    void ChangeCamera()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            float currentDistance = CinemachineFreeLook.m_Lens.FieldOfView;
            float newDistance = Mathf.Clamp(currentDistance - scrollInput * ZoomField, minDist, maxDist);
            CinemachineFreeLook.m_Lens.FieldOfView = newDistance;
        }
    }
    void BarsUpdate()
    {
        HealthSlider.value = transform.GetComponent<CharacterStatsBehavior>().Health;
        StaminaBar.value = transform.GetComponent<CharacterStatsBehavior>().Stamina;
    }
    void TestWindow()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Testwindow.gameObject.activeSelf)
            {
                Testwindow.gameObject.SetActive(false);
            }
            else
            {
                Testwindow.gameObject.SetActive(true);
            }
        }
        
    }

}
