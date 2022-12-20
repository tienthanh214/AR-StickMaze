using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { UP, RIGHT, DOWN, LEFT, JUMP }

public class Stickman : MonoBehaviour
{
    private Animator animator;
    private Direction curDir;
    public float moveSpeed = 5f;
    public float jumpSpeed = 2f;
    private Vector3 moveDirection;
    public CharacterController controller;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        curDir = Direction.UP;
        moveDirection = transform.forward;
        onCollideWithEffectTrigger();
    }

    private void FixedUpdate()
    {
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    // functionality
    public void changeDirection(Direction newDir)
    {
        float rot = ((int)newDir) * 90;
        // transform.rotation = Quaternion.Euler(0, rot, 0);
        transform.Rotate(transform.up, rot);
        // Debug.Log(transform.rotation.y + " " + curDir + " " + newDir);
        curDir = newDir;

    }

    public void jump()
	{
        animator.SetTrigger("IsJumping");
    }

    private void onCollideWithEffectTrigger()
    {
        Vector3 position = transform.position;
        Vector3 origin = new Vector3(position.x, position.y + 0.05f, position.z);
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, 0.1f, layerMask))
        {
            Debug.DrawRay(origin, direction * 0.1f, Color.red);
            if (hitInfo.distance < 0.02)
            {
                EffectTrigger effectTrigger = hitInfo.collider.gameObject.GetComponent<EffectTrigger>();
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
