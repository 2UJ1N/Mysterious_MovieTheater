using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Stage4Manager stageMG;

    private int sub1;
    private int sub2;

    // Start is called before the first frame update
    void Start()
    {
        sub1 = PlayerPrefs.GetInt("Sub1Clear");
        sub2 = PlayerPrefs.GetInt("Sub2Celar");
    }

    // Update is called once per frame
    void Update()
    {
        if (sub1 == 1 && sub2 == 1)
        {
            Stage4Manager.LastScript = true;
            Destroy(gameObject);
        }
    }

}
