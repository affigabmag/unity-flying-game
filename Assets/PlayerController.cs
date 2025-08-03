using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed =500f;

    void Update()
    {
        // Get input
        float moveVertical = Input.GetAxis("Vertical");     // W/S keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D keys

        // Declare and get turning input
        float turnInput = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            turnInput = -1f;
            Debug.Log("Q pressed");
        }
        if (Input.GetKey(KeyCode.E))
        {
            turnInput = 1f;
            Debug.Log("E pressed");
        }

        // Move forward/backward
        transform.Translate(Vector3.forward * moveVertical * speed * Time.deltaTime);

        // Strafe left/right
        transform.Translate(Vector3.right * moveHorizontal * speed * Time.deltaTime);

        // Turn with Q/E keys
        transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);
    }
}