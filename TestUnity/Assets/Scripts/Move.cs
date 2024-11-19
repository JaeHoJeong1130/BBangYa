using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 3.0f;

    public Camera fpsCam;
    public Camera ZoomCam;

    float rotateX;
    float rotateY;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        rotateX = Input.GetAxis("Mouse Y") * rotateSpeed;
        rotateY = Input.GetAxis("Mouse X") * rotateSpeed;

        transform.rotation *= Quaternion.Euler(0, rotateY, 0);
        fpsCam.transform.rotation *= Quaternion.Euler(-rotateX, 0, 0);
        ZoomCam.transform.rotation *= Quaternion.Euler(-rotateX, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1000.0f);
        }
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
