using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 verticalMovement = new Vector3(verticalInput * speed, 0.0f, verticalInput * speed);
        Vector3 horizontalMovement = new Vector3(horizontalInput * speed, 0.0f, -horizontalInput * speed);

        float x = Mathf.Clamp(verticalMovement.x + horizontalMovement.x, -1.0f, 1.0f);
        float z = Mathf.Clamp(verticalMovement.z + horizontalMovement.z, -1.0f, 1.0f);
        Vector3 movement = new Vector3(x * speed, 0.0f, z * speed);

        movement.y = GetComponent<Rigidbody>().velocity.y;

        GetComponent<Rigidbody>().velocity = movement;
    }
}
