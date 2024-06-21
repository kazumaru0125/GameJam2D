using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainScriput : MonoBehaviour
    {
    private bool isMoving = false;  // To check if the object should move
    public float speed = 5.0f;  // Speed at which the object moves to the right
    private Camera mainCamera;  // Reference to the main camera

    // Start is called before the first frame update
    void Start()
        {
        mainCamera = Camera.main;  // Initialize the camera reference
        }

    // Update is called once per frame
    void Update()
        {
        if (isMoving)
            {
            // Move the object to the right
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Check if the object is out of screen bounds
            Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
            if (screenPosition.x > 1.0f)  // If the object is out of the screen on the right
                {
                // Change the scene
                SceneManager.LoadScene("TestScene");  // Replace "YourNextSceneName" with the name of your scene
                }
            }
        }

    void OnTriggerEnter2D(Collider2D other)
        {
        // If the collided object has the tag "Player"
        if (other.gameObject.tag == "Player")
            {
            isMoving = true;  // Start moving the object
            }
        }
    }
