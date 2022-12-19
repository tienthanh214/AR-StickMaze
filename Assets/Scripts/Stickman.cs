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
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        curDir = Direction.UP;
        moveDirection = transform.forward;
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

}
