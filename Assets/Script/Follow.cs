using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // 화면 회전
    private float PlayerXRotValue;
    private float PlayeryRotvalue;
    private float HorizonRot;
    private float VerticalRot;

    private float mouseSensi = 100f; // 마우스 민감도

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
       //CameraRotation();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
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
}
