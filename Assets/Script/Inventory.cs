using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SloatsParent;

    private Slot[] slots;

    public static bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SloatsParent.GetComponentsInChildren<Slot>();
    }


    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                if (i == slots.Length - 1)
                    isFull = true;

                slots[i].AddItem(_item);
                return;
            }
        }

        Debug.Log("Inventory State: " + isFull);
    }
}
