using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public Transform cameraPosition;
    public float mouseSensitivity;
    public bool invertX;
    public bool invertY;

    private CharacterController characterController;
    private Vector3 movementVector;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //movementVector.x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        //movementVector.z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        Vector3 movementVertical = Input.GetAxis("Vertical") * transform.forward;
        Vector3 movementHorizontal = Input.GetAxis("Horizontal") * transform.right;

        movementVector = movementHorizontal + movementVertical;
        movementVector.Normalize();
        movementVector = movementVector * movementSpeed * Time.deltaTime;

        characterController.Move(movementVector);

        Vector2 mouseVector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        if (invertX)
        {
            mouseVector.x = -mouseVector.x;
        }
        if (invertY)
        {
            mouseVector.y = -mouseVector.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseVector.x, transform.rotation.eulerAngles.z);
        cameraPosition.rotation = Quaternion.Euler(cameraPosition.rotation.eulerAngles + new Vector3(mouseVector.y * -1, 0f, 0f));
        
        //Sound
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            if (!FindObjectOfType<AudioManager>().IsThisSoundPlaying("Floor"))
            {
                FindObjectOfType<AudioManager>().Play("Floor");
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("Floor");
        }
    }
}
