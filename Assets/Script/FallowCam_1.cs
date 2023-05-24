using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallowCam_1 : MonoBehaviour
{
    [SerializeField] private float mouseSensi = 100f; // 마우스 민감도

    // 화면 회전
    private float PlayerXRotValue;
    private float PlayeryRotvalue;
    private float HorizonRot;
    private float VerticalRot;

    // Raycas로 오브젝트 감지
    [SerializeField] private float MAX_RAY_DISTANCE = 100.0f;   // Ray 최대 거리
    private Transform _selection; // 선택된 오브젝트
    private RaycastHit rayHit;  // 레이에 맞은 오브젝트
    public LayerMask whatIsTarget; // 감지할 오브젝트의 레이어마스크

    //선택 오브젝트 Material 변경
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Vector3 ScreenCenter;   // 화면 중앙 좌표 저장

    // Start is called before the first frame update
    void Start()
    {
        // 마우스 커서 비활성화
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        
        HorizonRot = 0f;
        VerticalRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation(); // 카메라 회전
        CheckRay();
    }

    void CameraRotation()
    {
        HorizonRot = Input.GetAxisRaw("Mouse X") * mouseSensi * Time.deltaTime;
        VerticalRot = Input.GetAxisRaw("Mouse Y") * mouseSensi * Time.deltaTime;

        PlayerXRotValue += VerticalRot;
        PlayeryRotvalue += HorizonRot;

        PlayerXRotValue = Mathf.Clamp(PlayerXRotValue, -40f, 40f);

        transform.eulerAngles = new Vector3(-PlayerXRotValue, PlayeryRotvalue, 0f);
    }

    void CheckRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);

        // 선택된 오브젝트가 없을 경우
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        if (Physics.Raycast(ray, out rayHit, MAX_RAY_DISTANCE, whatIsTarget))
        {
            var selection = rayHit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();

            if (selectionRenderer != null)
                selectionRenderer.material = highlightMaterial;

            _selection = selection;
        }
    }

}
