using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider playerCollider;
    public float mouseSensitivity = 2.0f;
    public float playerSpeed = 2.0f;
    private Camera currentCamera;
    private CharacterController controller;
    // Start is called before the first frame update
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        currentCamera = Camera.main;
        // Should be scaled to fit character model
        controller.height = 0.1f;
        controller.radius = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X") * mouseSensitivity;
        float v = Input.GetAxis("Mouse Y") * mouseSensitivity;
        //controller.transform.Rotate(0, h, 0);
        controller.transform.RotateAround(playerCollider.bounds.center, Vector3.up, h);
        currentCamera.transform.RotateAround(playerCollider.bounds.center, currentCamera.transform.right, -v);

        if (Input.GetKey(KeyCode.W)){
            controller.Move(transform.forward * Time.deltaTime * playerSpeed);
        }

        if (Input.GetKey(KeyCode.S)){
            controller.Move(-transform.forward * Time.deltaTime * playerSpeed);
        }

        if (Input.GetKey(KeyCode.D)){
            Vector3 rotated = Quaternion.AngleAxis(90, Vector3.up) * transform.forward;
            controller.Move(rotated * Time.deltaTime * playerSpeed);
        }
        
        if (Input.GetKey(KeyCode.A)){
            Vector3 rotated = Quaternion.AngleAxis(-90, Vector3.up) * transform.forward;
            controller.Move(rotated * Time.deltaTime * playerSpeed);
        }

    }
}
