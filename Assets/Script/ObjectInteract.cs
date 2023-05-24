using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;

    private bool mIsOpen = false;
    private bool isItemNow = false;

    private float delayTiem = 1f;

    private void LateUpdate()
    {
        if (mIsOpen == true && isItemNow == false)
            StartCoroutine(EventDelay());
    }

    public void OnInteract()
    {
        Debug.Log("Interact Success: " + transform.name);
        mIsOpen = !mIsOpen;
        GetComponent<Animator>().SetBool("isOpen", mIsOpen);
    }

    private void ItemEvent()
    {
        if (mIsOpen == true && isItemNow == false)
        {
            if (transform.name == "Chest")
            {
                Vector3 direction = new Vector3(-90f, 0f, 0f);
                Vector3 pos = new Vector3(0f, 1f, 0f);
                Instantiate(itemPrefab, transform.position + pos, Quaternion.Euler(direction));
                isItemNow = true;
            }

            else if (transform.name == "Bed")
            {
                Vector3 direction = new Vector3(-90f, 0f, 0f);
                Vector3 pos = new Vector3(-0.2f, 1.5f, -0.25f);
                Instantiate(itemPrefab, transform.position + pos, Quaternion.Euler(direction));
                isItemNow = true;
            }

            else
            {
                Vector3 direction = new Vector3(-90f, 0f, 0f);
                Vector3 pos = new Vector3(0f, 1.7f, -0.5f);
                Instantiate(itemPrefab, transform.position + pos, Quaternion.Euler(direction));
                isItemNow = true;
            }
        }
    }

    IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(delayTiem);
        ItemEvent();
    }
}
