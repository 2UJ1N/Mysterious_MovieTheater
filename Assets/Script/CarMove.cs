using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMove : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);

        Destroy(gameObject, 5f);
    }
}
