using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent_Live : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpHeight;
    public float LookSpeed;
    public Transform CameraContainer;

    public float M_RAYLENGTH = 1.2f;

    private Rigidbody m_rigidbody;
    private Animator m_animator;

    private Vector3 m_processedMoveInput;
    private float m_processedTurnInput;
    private float m_processedLookInput;

    private float m_rotateSpeed = 60.0f;
    private bool m_isJumping;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        var rightInput = Input.GetAxis("Horizontal");
        var forwardInput = Input.GetAxis("Vertical");


        var isGrounded = IsGrounded();

        m_processedTurnInput = Input.GetAxis("Mouse X");
        m_processedLookInput = -Input.GetAxis("Mouse Y");


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            m_isJumping = true;
        }

        m_processedMoveInput = transform.forward * forwardInput + transform.right * rightInput;
        m_processedMoveInput = m_processedMoveInput.magnitude >= 1 ? m_processedMoveInput.normalized : m_processedMoveInput;

        CameraContainer.Rotate(new Vector3(m_processedLookInput, .0f, .0f) * LookSpeed * Time.deltaTime);


        m_animator.SetFloat("Speed", forwardInput);
        m_animator.SetBool("IsJumping", !isGrounded);

    }
    private void FixedUpdate()
    {
        m_rigidbody.MoveRotation(Quaternion.Euler(transform.eulerAngles + (Vector3.up * m_processedTurnInput) * Time.fixedDeltaTime * m_rotateSpeed));

        if (m_isJumping)
        {
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, 0, m_rigidbody.velocity.z);
            m_rigidbody.AddForce(JumpHeight * Vector3.up, ForceMode.Impulse);
            m_isJumping = false;
        }
        m_rigidbody.MovePosition(transform.position + m_processedMoveInput * MovementSpeed * Time.fixedDeltaTime);
    }
    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * M_RAYLENGTH, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit raycastHit, M_RAYLENGTH))
        {
            if (raycastHit.collider.gameObject.tag == "Ground")
            {
                return true;
            }
        }
        return false;
    }
}