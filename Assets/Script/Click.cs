using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0))

        {
            ui.SetActive(true);

        }

    }
}
