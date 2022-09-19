using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    // Start is called before the first frame update
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        // Should be scaled to fit character model
        controller.height = 0.1f;
        controller.radius = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * 2.0f);

    }
}
