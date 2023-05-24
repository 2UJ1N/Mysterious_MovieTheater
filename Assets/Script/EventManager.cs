using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject helper;   // ����� ������Ʈ
    public GameObject bearBig;  // ������ ������Ʈ
        
    [SerializeField] private Inventory inventory;
    [SerializeField] private Bear bearI;

    private bool eventStart = false; // ��ȣ�ۿ� �̺�Ʈ
    private bool chageBear = false; // �̺�Ʈ Ȯ�ο� ����
    private float delayTiem = 2.0f; // �����ð�

    // Update is called once per frame
    void Update()
    {  
        // ������ Ȱ��ȭ �� �ִϸ��̼� + ����� ��ȯ
        if (Inventory.isFull == true && chageBear == false)
        {  
            bearBig.SetActive(true);

            if (eventStart == true)
            {              
                bearI.OnInteractB();
                StartCoroutine(EventDelay());
            }
        }
    }

    public void checkEvent()
    {
        eventStart = true;
    }

    // ����� ��ȯ
    private void ActiveHelper()
    { 
            bearI.BearInterction();
            helper.SetActive(true);
            chageBear = true;
    }


    IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(delayTiem);
        ActiveHelper();
    }

}
