using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearStage : MonoBehaviour
{
    public GameObject Prefab;

    private int sub1;
    private int sub2;

    private int One;

    // Start is called before the first frame update
    void Start()
    {
        sub1 = PlayerPrefs.GetInt("Sub1Clear");
        sub2 = PlayerPrefs.GetInt("Sub2Clear");
    }

    // Update is called once per frame
    void Update()
    {
        StageClearCheck();

    }

    void StageClearCheck()
    {
        if(transform.name == "InsideOut" && PlayerPrefs.GetInt("Clear1") == 1)
        {
            if (PlayerPrefs.GetInt("AllClear")==0 && sub1 == 1)
            {
                Vector3 direction = new Vector3(-90f, 0f, 0f);
                Vector3 pos = new Vector3(0f, 1f, -1f);
                Instantiate(Prefab, transform.position + pos, Quaternion.Euler(direction));
                PlayerPrefs.SetInt("Clear1", 2);
            }
        }

        if (transform.name == "Shooting")
        {
            if (sub2 == 1 && PlayerPrefs.GetInt("Clear2")==1)
            {
                Vector3 direction = new Vector3(-90f, 0f, 0f);
                Vector3 pos = new Vector3(0f, 1f, 1f);
                PlayerPrefs.SetInt("Clear2", 2);
                PlayerPrefs.SetInt("AllClear", 1);
                Instantiate(Prefab, transform.position + pos, Quaternion.Euler(direction));
            }
        }

    }
}
