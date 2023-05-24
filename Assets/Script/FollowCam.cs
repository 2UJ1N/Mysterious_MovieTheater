using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private float mouseSensi = 100f; // 마우스 민감도

    // 화면 회전
    private float PlayerXRotValue;
    private float PlayeryRotvalue;
    private float HorizonRot;
    private float VerticalRot;

    public float x;
    public float y;
    public float z;
    public GameObject player;
    private Vector3 ScreenCenter;   // 화면 중앙 좌표 저장

    // Start is called before the first frame update
    void Start()
    {
        // 마우스 커서 비활성화
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        HorizonRot = 0f;
        VerticalRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation(); // 카메라 회전
        
        transform.position = player.transform.position + new Vector3(x, y, z);
    }

    void CameraRotation()
    {
        HorizonRot = Input.GetAxisRaw("Mouse X") * mouseSensi * Time.deltaTime;
        VerticalRot = Input.GetAxisRaw("Mouse Y") * mouseSensi * Time.deltaTime;

        PlayerXRotValue += VerticalRot;
        PlayeryRotvalue += HorizonRot;

        PlayerXRotValue = Mathf.Clamp(PlayerXRotValue, -20f, 20f);

        transform.eulerAngles = new Vector3(-PlayerXRotValue, PlayeryRotvalue, 0f);
        
    }


}
