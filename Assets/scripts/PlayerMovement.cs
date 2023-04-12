using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{

    private float speed = 1f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public Animator moveAnimator;
    private float currSpeed;

    private float jumpHeight = 1f;
    private float gravity = -9.81f;
    private Vector3 velocity = Vector3.zero;

    public CharacterController controller;


    void Update()
    {
        MoveCharacter();
    }


    void MoveCharacter()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Return angle between x and y (y/x) but we moving to x to y so (x/y)
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // For smoothing transition
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


            // Add jump functionality
            bool isGrounded = controller.isGrounded;
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

                velocity.y += gravity * Time.deltaTime;
                controller.Move((velocity + (transform.forward * vertical + transform.right * horizontal).normalized * currSpeed) * Time.deltaTime);
                JumpAnimation(direction);
            }
            controller.Move(moveDir.normalized * currSpeed * Time.deltaTime);
        }

        WalkingAnimation(direction);

    }

    void WalkingAnimation(Vector3 direction)
    {

        moveAnimator.SetFloat("MoveSpeed", direction.magnitude);
    }

    void JumpAnimation(Vector3 direction)
    {

        moveAnimator.SetTrigger("Jumping");
    }
}

