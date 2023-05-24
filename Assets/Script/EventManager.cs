using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject helper;   // 도우미 오브젝트
    public GameObject bearBig;  // 곰인형 오브젝트
        
    [SerializeField] private Inventory inventory;
    [SerializeField] private Bear bearI;

    private bool eventStart = false; // 상호작용 이벤트
    private bool chageBear = false; // 이벤트 확인용 변수
    private float delayTiem = 2.0f; // 지연시간

    // Update is called once per frame
    void Update()
    {  
        // 곰인형 활성화 후 애니메이션 + 도우미 소환
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

    // 도우미 소환
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
