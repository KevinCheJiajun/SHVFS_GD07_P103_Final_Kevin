using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent_Live : MonoBehaviour
{
    public float movementSpeed;
    public float lookSpeed;
    public Transform cameraContainer;

    private Rigidbody rigidbody;
    private Animator animator;
    private Sword sword;

    public string Horizontal;
    public string Vertical;
    public string MouseX;
    public string MouseY;
    //public KeyCode ;
    //public KeyCode up;
    //public KeyCode down;

    private Vector3 processedMoveInput;
    private float processedTurnInput;
    private float processedLookInput;

    public float rotateSpeed = 60.0f;
    //public float rayLength = 1.2f;
    //private bool isJumping;
    //public float jumpHeight;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        sword = GetComponentInChildren<Sword>();
    }

    private void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        var rightInput = Input.GetAxis(Horizontal);
        var forwardInput = Input.GetAxis(Vertical);
        processedTurnInput = Input.GetAxis(MouseX);
        //processedLookInput = -Input.GetAxis(MouseY);

        #region Jump
        //var isGrounded = IsGrounded();
        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    isJumping = true;
        //}
        //animator.SetBool("IsJumping", !isGrounded);
        #endregion

        processedMoveInput = transform.forward * forwardInput + transform.right * rightInput;
        processedMoveInput = processedMoveInput.magnitude >= 1 ? processedMoveInput.normalized : processedMoveInput;

        cameraContainer.Rotate(new Vector3(processedLookInput, .0f, .0f) * lookSpeed * Time.deltaTime);


        animator.SetFloat("Speed", forwardInput);
    }

    private void FixedUpdate()
    {
        rigidbody.MoveRotation(Quaternion.Euler(transform.eulerAngles + (Vector3.up * processedTurnInput) * Time.fixedDeltaTime * rotateSpeed));
        rigidbody.MovePosition(transform.position + processedMoveInput * movementSpeed * Time.fixedDeltaTime);
        #region isJuming
        //if (isJumping)
        //{
        //    rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        //    rigidbody.AddForce(jumpHeight * Vector3.up, ForceMode.Impulse);
        //    isJumping = false;
        //}
        #endregion
    }

    //private bool IsGrounded()
    //{
    //    Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
    //    if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHit, rayLength))
    //    {
    //        if (raycastHit.collider.gameObject.tag == "Ground")
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
}