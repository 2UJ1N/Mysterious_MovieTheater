using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondtrol_2 : MonoBehaviour
{
    // ĳ���� ������
    Vector3 direction;  // ī�޶� �ٶ󺸴� ����
    float speed = 2.5f;   // �̵��ӵ�
    float h;    // Horizontal
    float v;    // Vertical

    // ĳ���� ��ȣ�ۿ�
    private float range = 500f;   // ray Ž�� ����
    private bool pickupActivated = false;   // ������ ���� ���� ����
    private bool InteractActivated = false;   // ������ ���� ���� ����
    private Vector3 ScreenCenter;   // ȭ�� �߾� ��ǥ
    private RaycastHit hit;
    private Ray ray;

    [SerializeField] private LayerMask layerMask; // Ư�� ���̾ ���� ������Ʈ�� ��ȯ
    [SerializeField] private GameObject TextPanel; // ������ ��ȣ�ۿ� �ؽ�Ʈ
    [SerializeField] private Inventory inventory; // �κ��丮

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
        TextPanel.GetComponentInChildren<Text>().text = "F�� ���� " + hit.transform.name + "��(��) ��ȣ�ۿ��ϱ�";
    }

    private void InfoDisappear()
    {
        InteractActivated = false;
        TextPanel.SetActive(false);
    }

    // �繰 ��ȣ�ۿ�
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

    // ������ ����
    private void CanPickup()
    {
        if (pickupActivated)
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.GetComponent<ItemPickup>().item.itemName + " ȹ�� �߽��ϴ�.");
                inventory.AcquireItem(hit.transform.GetComponent<ItemPickup>().item);
                Destroy(hit.transform.gameObject);
                InfoDisappear();
            }
        }
    }
}
