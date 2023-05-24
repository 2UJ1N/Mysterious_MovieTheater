using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunContoller : MonoBehaviour
{
    // 캐릭터 움직임
    Vector3 direction;  // 카메라가 바라보는 방향
    float h;    // Horizontal
    float v;    // Vertical

    private Rigidbody playerRigidbody;
    public float speed = 2f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 heading = Camera.main.transform.localRotation * Vector3.forward;
        heading.y = 0;
        heading = heading.normalized;

        direction = heading * Time.deltaTime * v * speed;
        direction += Quaternion.Euler(0f, 90f, 0f) * heading * Time.deltaTime * h * speed;

        transform.Translate(direction);

        if (Input.GetKey(KeyCode.W) == true)
            animator.SetFloat("Move", 1f, 0.1f, Time.deltaTime);
        else if (Input.GetKey(KeyCode.S) == true)
        {
            animator.SetFloat("Move", -1f, -0.1f, Time.deltaTime);
        }   
        else if (Input.GetKey(KeyCode.A) == true)   //Left
            animator.SetFloat("Direction", -1f, 0.1f, Time.deltaTime);
        else if (Input.GetKey(KeyCode.D) == true)   //Right
            animator.SetFloat("Direction", 1f, 0.1f, Time.deltaTime);
        else
        {
            animator.SetFloat("Direction", 0f, 0.1f, Time.deltaTime);
            animator.SetFloat("Move", 0f, 0.1f, Time.deltaTime);
        }
    }
    
}
