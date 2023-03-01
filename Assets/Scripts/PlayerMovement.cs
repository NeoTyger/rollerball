using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _playerRigidbody;

    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 100.0f;
    [SerializeField] private float jumpForce = 3.0f;
    private bool onPlatform = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        
        transform.Translate(0, 0, movement);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown(KeyCode.Space) && onPlatform == true)
        {
            _playerRigidbody = gameObject.GetComponent<Rigidbody>();
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onPlatform = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onPlatform = true;
        }
    }
}
