using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f, jumpValue = 10f;
    [SerializeField] private Rigidbody rigidBody;
    private Boolean isGround = false;
    [SerializeField] public UIGameplay uiGameplay;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Movement(float horizontal, float vertical)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        Vector3 moveVelocity = move * moveSpeed;
        Vector3 newPosition = rigidBody.position + moveVelocity * Time.fixedDeltaTime;
        rigidBody.MovePosition(newPosition);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigidBody.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            isGround = false;
            Debug.Log("Jump Clicked");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            uiGameplay.ShowGameOver();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Movement(horizontal, vertical);
    }
}
