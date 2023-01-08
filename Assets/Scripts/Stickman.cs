using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { UP, RIGHT, DOWN, LEFT, JUMP }

[System.Serializable]
public class StickmanAttributes
{
    public float moveSpeed;
    public float jumpSpeed;
    private int HP = 1;

    public bool ChangeHP(int amount)
	{
        HP += amount;
        if (HP <= 0)
		{
            return false;
		}
        return true;
	}

    public void SetMoveSpeed(int speed)
	{
        this.moveSpeed = speed;
	}

    public void SetJumpSpeed(int speed)
	{
        this.jumpSpeed = speed;
	}

    public void GameOver()
	{
        moveSpeed = 0;
        jumpSpeed = 0;
	}
}

public class Stickman : MonoBehaviour
{
    public StickmanAttributes attributes = new StickmanAttributes();

    [SerializeField] float m_GroundCheckDistance = 0.1f;
    [Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 2f;

    private Animator m_Animator;

    private Vector3 moveDirection;
    public CharacterController controller;
    Rigidbody m_Rigidbody;
    float m_OrigGroundCheckDistance;

    bool m_IsGrounded;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
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
            m_Rigidbody.velocity = moveDirection * attributes.moveSpeed;
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
        onCollideWithEffectTrigger();
    }

    private void FixedUpdate()
    {
        
    }

    // functionality
    public void changeDirection(Direction newDir)
    {
        float rot = ((int)newDir) * 90;
        transform.Rotate(transform.up, rot);
    }

    public void changeDirection(Vector3 rot)
	{
        int iter = Mathf.CeilToInt(rot.y) / 90;
        if (Mathf.CeilToInt(Mathf.Abs(rot.y)) % 90 > 45)
            iter++;
        transform.rotation = Quaternion.Euler(0, iter * 90, 0);
	}

    public void jump()
	{

        m_Rigidbody.AddForce(transform.up * attributes.jumpSpeed + transform.forward * (attributes.moveSpeed), ForceMode.Impulse);

        m_IsGrounded = false;
        m_Animator.applyRootMotion = false;
        m_GroundCheckDistance = 0.1f;
        m_Animator.SetTrigger("IsJumping");
    }

    public void damaged(int p)
    {
        if (!attributes.ChangeHP(-p))
		{
            die();
		}
    }

    private void die()
    {
        m_Animator.SetTrigger("IsDied");
        attributes.GameOver();
    }

    public void winGame()
	{
        m_Animator.SetBool("IsDancing", true);
        attributes.GameOver();
        GameManager.Instance.AchievedStickman();
	}

    void CheckGroundStatus()
	{
        RaycastHit hitInfo;

        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            // m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
            m_Animator.applyRootMotion = false;
        }
        else
        {
            m_IsGrounded = false;
            // m_GroundNormal = Vector3.up;
            m_Animator.applyRootMotion = false;
        }
    }

    private void onCollideWithEffectTrigger()
    {
        Vector3 position = transform.position;
        Vector3 origin = new Vector3(position.x, position.y + 0.05f, position.z) - transform.forward * 0.05f;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, 0.1f, layerMask))
        {
            Debug.DrawRay(origin, direction * 0.1f, Color.red);
            if (hitInfo.distance < 0.02)
            {
                EffectTrigger effectTrigger = hitInfo.collider.gameObject.GetComponent<EffectTrigger>();
                if (effectTrigger == null)
                    return;
                effectTrigger.ApplyEffect(this);
                Debug.Log("Stickman hit effect: " + effectTrigger.effect.ToString());
            }
        }
        else
        {
            Debug.DrawRay(origin, direction * 0.1f, Color.green);
        }
    }
}
