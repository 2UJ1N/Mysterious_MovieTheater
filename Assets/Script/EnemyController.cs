using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 2f;
    public int energy = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullet"))
        {
            energy -= 1;
        }
        else return;

        if(energy <= 0)
        {
            Destroy(this.gameObject, 0.0f);
        }
    }
}
