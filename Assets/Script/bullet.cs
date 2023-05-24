using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null)
            {
                
            }
        }
    }
}
