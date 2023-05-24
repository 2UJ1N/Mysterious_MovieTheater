using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl_1 : MonoBehaviour
{
    public EventManager eventM;

    // ĳ���� ������
    Vector3 direction;  // ī�޶� �ٶ󺸴� ����
    float speed = 2f;   // �̵��ӵ�
    float h;    // Horizontal
    float v;    // Vertical

    // ĳ���� ��ȣ�ۿ�
    private float range = 2f;   // ray Ž�� ����
    private bool pickupActivated = false;   // ������ ���� ���� ����
    private bool InteractActivated = false;   // ������ ���� ���� ����
    private Vector3 ScreenCenter;   // ȭ�� �߾� ��ǥ
    private RaycastHit hit;
    private Ray ray;

    [SerializeField] private LayerMask layerMask; // Ư�� ���̾ ���� ������Ʈ�� ��ȯ
    [SerializeField] private GameObject TextPanel; // ������ ��ȣ�ۿ� �ؽ�Ʈ
    [SerializeField] private Inventory inventory; // �κ��丮

    // ������Ʈ ��ȣ�ۿ�
    [SerializeField] private ObjectInteract chest;  // ����
    [SerializeField] private ObjectInteract bedCase;   // ħ�����
    [SerializeField] private ObjectInteract dresser;   // ������
    

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

    // ĳ���� �̵�
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

    // ������Ʈ(�繰,������) ��ȣ�ۿ� Ű
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

    // ������Ʈ Ȯ��
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

    // ������ ����â Ȱ��ȭ
    private void ItemInfoAppear()
    {
        pickupActivated = true;
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "Press " + "<color=yellow>" + "E " + "</color>" + "to pick up the " + hit.transform.GetComponent<ItemPickup>().item.itemName;
    }

    // �繰 ����â Ȱ��ȭ
    private void ObjectInfoAppear()
    {
        InteractActivated = true;
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "Press " + "<color=yellow>" + "F " + "</color>" + "to interact the " + hit.transform.name;
    }

    // ����â ��Ȱ��ȭ
    private void InfoDisappear()
    {
        if (pickupActivated == true)
            pickupActivated = false;

        if (InteractActivated == true)
            InteractActivated = false;

        TextPanel.SetActive(false);
    }

    // ������ ����
    private void CanPickup()
    {
        if(pickupActivated)
        {
            if(hit.transform!=null)
            {
                Debug.Log(hit.transform.GetComponent<ItemPickup>().item.itemName + " ȹ�� �߽��ϴ�.");
                inventory.AcquireItem(hit.transform.GetComponent<ItemPickup>().item);
                Destroy(hit.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    // �繰 ��ȣ�ۿ�
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
