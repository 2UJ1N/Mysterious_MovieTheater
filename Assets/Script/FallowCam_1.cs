using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallowCam_1 : MonoBehaviour
{
    [SerializeField] private float mouseSensi = 100f; // ���콺 �ΰ���

    // ȭ�� ȸ��
    private float PlayerXRotValue;
    private float PlayeryRotvalue;
    private float HorizonRot;
    private float VerticalRot;

    // Raycas�� ������Ʈ ����
    [SerializeField] private float MAX_RAY_DISTANCE = 100.0f;   // Ray �ִ� �Ÿ�
    private Transform _selection; // ���õ� ������Ʈ
    private RaycastHit rayHit;  // ���̿� ���� ������Ʈ
    public LayerMask whatIsTarget; // ������ ������Ʈ�� ���̾��ũ

    //���� ������Ʈ Material ����
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Vector3 ScreenCenter;   // ȭ�� �߾� ��ǥ ����

    // Start is called before the first frame update
    void Start()
    {
        // ���콺 Ŀ�� ��Ȱ��ȭ
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        
        HorizonRot = 0f;
        VerticalRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation(); // ī�޶� ȸ��
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

        // ���õ� ������Ʈ�� ���� ���
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
