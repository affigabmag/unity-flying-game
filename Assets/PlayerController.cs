using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 500f;
    public float rollAmount = 30f;      // How much to roll (degrees)
    public float rollSpeed = 5f;        // How fast to roll
    private float currentRoll = 0f;     // Current roll angle

    void Update()
    {
        // Auto forward flight (always horizontal, unaffected by roll)
        transform.Translate(Vector3.forward * speed * 1.0f * Time.deltaTime);

        // Check boundaries and U-turn
        float boundary = 90f; // Adjust based on your city size
        if (transform.position.x > boundary || transform.position.x < -boundary ||
            transform.position.z > boundary || transform.position.z < -boundary)
        {
            transform.Rotate(0, 180, 0); // U-turn
        }

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

        // Roll animation based on input
        float targetRoll = 0f;

        // Calculate target roll based on input
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            targetRoll = rollAmount;  // Roll left
        }
        else if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.D))
        {
            targetRoll = -rollAmount; // Roll right
        }

        // Smoothly interpolate to target roll
        currentRoll = Mathf.Lerp(currentRoll, targetRoll, rollSpeed * Time.deltaTime);

        // Apply roll only to the visual airplane (child), not the parent movement
        Transform airplaneVisual = transform.Find("zero");
        if (airplaneVisual != null)
        {
            airplaneVisual.rotation = Quaternion.Euler(0, transform.eulerAngles.y, currentRoll);
        }
    }
}