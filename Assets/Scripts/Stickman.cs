using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { UP, RIGHT, DOWN, LEFT, JUMP }

public class Stickman : MonoBehaviour
{
    [SerializeField] float m_GroundCheckDistance = 0.1f;
    [Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;

    private Animator m_Animator;
    private Direction curDir;
    public float moveSpeed = 0.5f;
    public float jumpSpeed = 4f;
    private Vector3 moveDirection;
    public CharacterController controller;
    Rigidbody m_Rigidbody;
    float m_OrigGroundCheckDistance;


    Vector3 m_GroundNormal;
    bool m_IsGrounded;
    // Start is called before the first frame update

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        curDir = Direction.UP;
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        m_OrigGroundCheckDistance = m_GroundCheckDistance;

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = transform.forward;
        //moveDirection = transform.InverseTransformDirection(moveDirection);
        CheckGroundStatus();
        //moveDirection = Vector3.ProjectOnPlane(moveDirection, m_GroundNormal);
        if (m_IsGrounded)
		{
            m_Rigidbody.velocity = moveDirection * moveSpeed;
        }
        else
		{
            Vector3 extraGravityForce = (Physics.gravity * m_GravityMultiplier) - Physics.gravity;
            m_Rigidbody.AddForce(extraGravityForce);
            m_GroundCheckDistance = m_Rigidbody.velocity.y < 0 ? m_OrigGroundCheckDistance : 0.01f;
        }
        if(Input.GetMouseButtonDown(0))
		{
            jump();
		}
    }

    private void FixedUpdate()
    {
        
    }

    // functionality
    public void changeDirection(Direction newDir)
    {
        float rot = ((int)newDir) * 90;
        transform.Rotate(transform.up, rot);
        curDir = newDir;
    }

    public void jump()
	{

        m_Rigidbody.AddForce(transform.up * jumpSpeed + transform.forward * (moveSpeed / 2), ForceMode.Impulse);

        m_IsGrounded = false;
        m_Animator.applyRootMotion = false;
        m_GroundCheckDistance = 0.1f;
        m_Animator.SetTrigger("IsJumping");

    }



    void CheckGroundStatus()
	{
        RaycastHit hitInfo;

        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
            m_Animator.applyRootMotion = false;
        }
        else
        {
            m_IsGrounded = false;
            m_GroundNormal = Vector3.up;
            m_Animator.applyRootMotion = false;
        }
    }

}
