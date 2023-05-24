using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondtrol_2 : MonoBehaviour
{
    // 캐릭터 움직임
    Vector3 direction;  // 카메라가 바라보는 방향
    float speed = 2.5f;   // 이동속도
    float h;    // Horizontal
    float v;    // Vertical

    // 캐릭터 상호작용
    private float range = 500f;   // ray 탐지 범위
    private bool pickupActivated = false;   // 아이템 습득 가능 여부
    private bool InteractActivated = false;   // 아이템 습득 가능 여부
    private Vector3 ScreenCenter;   // 화면 중앙 좌표
    private RaycastHit hit;
    private Ray ray;

    [SerializeField] private LayerMask layerMask; // 특정 레이어를 가진 오브젝트만 반환
    [SerializeField] private GameObject TextPanel; // 아이템 상호작용 텍스트
    [SerializeField] private Inventory inventory; // 인벤토리

    [SerializeField] private Stage4Manager stageMG;

    [SerializeField] private ItemPickup I1;
    [SerializeField] private ItemPickup I2;

    int sub1;
    int sub2;

    bool tryOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        sub1 = PlayerPrefs.GetInt("Sub1Clear");
        sub2 = PlayerPrefs.GetInt("Sub2Celar");

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Check();
        TryAction();

        if (sub1 == 1 && sub2 == 1 && tryOnce == false)
        {
            inventory.AcquireItem(I1.item);
            //inventory.AcquireItem(I2.item);
            tryOnce = true;
        }
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

    private void Check()
    {
        ray = Camera.main.ScreenPointToRay(ScreenCenter);

        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.tag == "InteractableObj")
                ObjectInfoAppear();

            else if (hit.transform.tag == "Item")
                ItemInfoApper();
        }

        else
            InfoDisappear();

    }
    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Check();
            CanInteract();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Check();
            CanPickup();
        }

    }

    private void ItemInfoApper()
    {
        pickupActivated = true;
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "Press " + "<color=yellow>" + "E " + "</color>" + "to pick up the " + hit.transform.GetComponent<ItemPickup>().item.itemName;
    }

    private void ObjectInfoAppear()
    {
        InteractActivated = true;
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "F를 눌러 " + hit.transform.name + "와(과) 상호작용하기";
    }

    private void InfoDisappear()
    {
        InteractActivated = false;
        TextPanel.SetActive(false);
    }

    // 사물 상호작용
    private void CanInteract()
    {
        if (InteractActivated && hit.transform != null)
        {
            if (hit.transform.name == "InsideOut")
                stageMG.NextStage(2);

            if (hit.transform.name == "Shooting")
                stageMG.NextStage(3);

            if (hit.transform.name == "Elevator")
                stageMG.NextStage(7);
        }
    }

    // 아이템 수집
    private void CanPickup()
    {
        if (pickupActivated)
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.GetComponent<ItemPickup>().item.itemName + " 획득 했습니다.");
                inventory.AcquireItem(hit.transform.GetComponent<ItemPickup>().item);
                Destroy(hit.transform.gameObject);
                InfoDisappear();
            }
        }
    }
}
