using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bear : MonoBehaviour
{
    [SerializeField] private GameObject TextPanel; // 아이템 상호작용 텍스트
    [SerializeField] private Inventory inven;

    public HUDManager hud;

    private bool first = false;

    public void OnInteractB()
    {
        Debug.Log("Interact Success: " + transform.name);
        GetComponent<Animator>().SetBool("interact", true);
    }

    public void ObjectInfoAppear()
    {
        TextPanel.SetActive(true);
        TextPanel.GetComponentInChildren<Text>().text = "Press " + "<color=yellow>" + "F " + "</color>" + "to pick up the " + transform.name;
    }

    public void BearInterction()
    {
        if (Inventory.isFull == true && first == false)
        {
            first = true;
            Destroy(gameObject);
        }
    }

}
