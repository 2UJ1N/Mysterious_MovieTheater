using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl_1 : MonoBehaviour
{
    public EventManager eventM;

    // 캐릭터 움직임
    Vector3 direction;  // 카메라가 바라보는 방향
    float speed = 2f;   // 이동속도
    float h;    // Horizontal
    float v;    // Vertical

    // 캐릭터 상호작용
    private float range = 2f;   // ray 탐지 범위
    private bool pickupActivated = false;   // 아이템 습득 가능 여부
    private bool InteractActivated = false;   // 아이템 습득 가능 여부
    private Vector3 ScreenCenter;   // 화면 중앙 좌표
    private RaycastHit hit;
    private Ray ray;

    [SerializeField] private LayerMask layerMask; // 특정 레이어를 가진 오브젝트만 반환
    [SerializeField] private GameObject TextPanel; // 아이템 상호작용 텍스트
    [SerializeField] private Inventory inventory; // 인벤토리

    // 오브젝트 상호작용
    [SerializeField] private ObjectInteract chest;  // 상자
    [SerializeField] private ObjectInteract bedCase;   // 침대옷장
    [SerializeField] private ObjectInteract dresser;   // 수납장
    

    // Start is called before the first frame update
    void Start()
    { 
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Check();
        TryAction();
    }

    // 캐릭터 이동
    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 heading = Camera.main.transform.localRotation * Vector3.forward;
        heading.y = 0;
        heading = heading.normalized;

        direction = heading * Time.deltaTime * v * speed;
        direction += Quaternion.Euler(0f, 90f, 0f) * heading * Time.deltaTime * h * speed;

        transform.Translate(direction);
    }

    // 오브젝트(사물,아이템) 상호작용 키
    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Check();
            CanInteract();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Check();
            CanPickup();
        }
    }

    // 오브젝트 확인
    private void Check()
    {
        ray = Camera.main.ScreenPointToRay(ScreenCenter);

        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            if (hit.transform.tag == "Item")
                ItemInfoAppear();

            else if (hit.transform.tag == "InteractableObj")
                ObjectInfoAppear();
        }

        else
            InfoDisappear();
    }

    // 아이템 정보창 활성화
    private void ItemInfoAppear()
    {
        pickupActivated = true;
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "Press " + "<color=yellow>" + "E " + "</color>" + "to pick up the " + hit.transform.GetComponent<ItemPickup>().item.itemName;
    }

    // 사물 정보창 활성화
    private void ObjectInfoAppear()
    {
        InteractActivated = true;
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "Press " + "<color=yellow>" + "F " + "</color>" + "to interact the " + hit.transform.name;
    }

    // 정보창 비활성화
    private void InfoDisappear()
    {
        if (pickupActivated == true)
            pickupActivated = false;

        if (InteractActivated == true)
            InteractActivated = false;

        TextPanel.SetActive(false);
    }

    // 아이템 수집
    private void CanPickup()
    {
        if(pickupActivated)
        {
            if(hit.transform!=null)
            {
                Debug.Log(hit.transform.GetComponent<ItemPickup>().item.itemName + " 획득 했습니다.");
                inventory.AcquireItem(hit.transform.GetComponent<ItemPickup>().item);
                Destroy(hit.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    // 사물 상호작용
    private void CanInteract()
    {
        if (InteractActivated && hit.transform != null)
        {
            if (hit.transform.name == "Bed")
                bedCase.OnInteract();

            else if (hit.transform.name == "Chest")
                chest.OnInteract();

            else if (hit.transform.name == "Dresser")
                dresser.OnInteract();

            else if (hit.transform.name == "BearBig")
                eventM.checkEvent();
        }
    }
}
