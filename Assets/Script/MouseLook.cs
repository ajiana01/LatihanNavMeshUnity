using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseLook : MonoBehaviour
{
    [FormerlySerializedAs("_mouseSens")] [SerializeField] public float mouseSens = 100f;
    [SerializeField] public Transform playerBody;
    private float _xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime ;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
