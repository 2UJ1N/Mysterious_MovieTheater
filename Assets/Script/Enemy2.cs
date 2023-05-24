using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent nav;
    public int energy = 2;

    void Awake()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;

        //nav = GetComponent <NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullet"))
        {
            energy -= 1;
        }
        else return;

        if (energy <= 0)
            Destroy(this.gameObject, 0.0f);
    }

    void Die()
    {
        Destroy(this.gameObject, 0.0f);
    }

}
