using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charactercontroller;
    [SerializeField]
    public float speed = 5f;
    private Animator animator;
    [SerializeField]
    public float turnspeed = 5f;
    private Rigidbody rb;

    private void Awake()
    {
        charactercontroller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        animator.SetBool("Aiming", false);

        animator.SetFloat("Speed", movement.magnitude);
        if(movement.magnitude > 0.3)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("Aiming", false);
            animator.SetTrigger("Jump");
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Aiming", true);
            animator.SetTrigger("Attack");  
        }

        if (Input.GetButton("Escape"))
        {
            Cursor.visible = true;
            Debug.Log("Escape");
        }
    }
}
