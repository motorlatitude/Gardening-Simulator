using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider playerCollider;
    public float mouseSensitivity = 2.0f;
    public float playerSpeed = 2.0f;
    public float playerSpeedModifier = 1.5f;
    private Camera currentCamera;
    private CharacterController controller;
    // Start is called before the first frame update
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        currentCamera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen, required for  accurate mouse positioning for placing objects
        // Center entire controller (including camera) on the player
        controller.center = playerCollider.bounds.center;
        currentCamera.transform.position = playerCollider.bounds.center;
        controller.enableOverlapRecovery = true;
        // Should be scaled to fit character model
        controller.height = 0.1f;
        controller.radius = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X") * mouseSensitivity;
        float v = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera around the player horizontally
        controller.transform.RotateAround(playerCollider.bounds.center, Vector3.up, h);

        //Restrict camera movement to 180 degrees in the vertical axis to avoid looking upside down
        if(currentCamera.transform.localEulerAngles.x - v > 270 || currentCamera.transform.localEulerAngles.x - v < 90) {
            // Rotate the camera around the player vertically
            currentCamera.transform.RotateAround(playerCollider.bounds.center, currentCamera.transform.right, -v);
        }

        float modifiedSpeed = playerSpeed;

        if(Input.GetKey(KeyCode.LeftShift)){
            modifiedSpeed = playerSpeed*playerSpeedModifier;
        }

        if (Input.GetKey(KeyCode.W)){
            controller.Move(transform.forward * Time.deltaTime * modifiedSpeed);
        }

        if (Input.GetKey(KeyCode.S)){
            controller.Move(-transform.forward * Time.deltaTime * modifiedSpeed);
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
