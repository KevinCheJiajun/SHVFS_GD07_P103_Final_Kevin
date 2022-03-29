using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent_Live : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    public float lookSpeed;
    public Transform cameraContainer;

    public float rayLength = 1.2f;

    private Rigidbody rigidbody;
    private Animator animator;
    private Sword sword;


    private Vector3 processedMoveInput;
    private float processedTurnInput;
    private float processedLookInput;

    private float rotateSpeed = 60.0f;
    private bool isJumping;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        sword = GetComponentInChildren<Sword>();
    }

    private void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        var rightInput = Input.GetAxis("Horizontal");
        var forwardInput = Input.GetAxis("Vertical");


        var isGrounded = IsGrounded();

        processedTurnInput = Input.GetAxis("Mouse X");
        processedLookInput = -Input.GetAxis("Mouse Y");


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        processedMoveInput = transform.forward * forwardInput + transform.right * rightInput;
        processedMoveInput = processedMoveInput.magnitude >= 1 ? processedMoveInput.normalized : processedMoveInput;

        cameraContainer.Rotate(new Vector3(processedLookInput, .0f, .0f) * lookSpeed * Time.deltaTime);


        animator.SetFloat("Speed", forwardInput);
        animator.SetBool("IsJumping", !isGrounded);
    }

    private void FixedUpdate()
    {
        rigidbody.MoveRotation(Quaternion.Euler(transform.eulerAngles + (Vector3.up * processedTurnInput) * Time.fixedDeltaTime * rotateSpeed));

        if (isJumping)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            rigidbody.AddForce(jumpHeight * Vector3.up, ForceMode.Impulse);
            isJumping = false;
        }
        rigidbody.MovePosition(transform.position + processedMoveInput * movementSpeed * Time.fixedDeltaTime);
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHit, rayLength))
        {
            if (raycastHit.collider.gameObject.tag == "Ground")
            {
                return true;
            }
        }
        return false;
    }
}