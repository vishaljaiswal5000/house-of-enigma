using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float jumpForce = 10f;
    //private Rigidbody rigidbody;

    //void Start()
    //{
    //    rigidbody = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

    //    transform.position += movement * Time.deltaTime * movementSpeed;

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }
    //}

    //public Animator moveAnimator;
    //private Vector3 movement;
    //private float movementSqrMagnitude;
    //public Transform playerTransform;

    //void Update()
    //{
    //    GetMovementInput();
    //    CharacterRotation();
    //    WalkingAnimation();
    //    CameraRotate();
    //}

    //void GetMovementInput()
    //{
    //    movement.x = Input.GetAxis("Horizontal");
    //    movement.z = Input.GetAxis("Vertical");
    //    movement = Vector3.ClampMagnitude(movement, 1.0f);
    //    movementSqrMagnitude = movement.sqrMagnitude;
    //}


    //void CharacterRotation()
    //{
    //    if (movement != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
    //    }
    //}


    //void WalkingAnimation()
    //{
    //    moveAnimator.SetFloat("MoveSpeed", movementSqrMagnitude);
    //}

    //void CameraRotate()
    //{
    //    float angle = Input.GetKey(KeyCode.J) ? -20.0f : 0.0f;
    //    angle = Input.GetKey(KeyCode.L) ? 20.0f : angle;
    //    Camera.main.transform.Rotate(Vector3.up, angle * Time.deltaTime, Space.World);
    //}





    public CharacterController controller;
    private float speed = 1f;
    private float runSpeed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public Animator moveAnimator;
    private float currSpeed;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Return angle between x and y (y/x) but we moving to x to y so (x/y)
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // For smoothing transition
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currSpeed = runSpeed;
            }
            else
            {
                currSpeed = speed;
            }

            controller.Move(moveDir.normalized * currSpeed * Time.deltaTime);
        }
        WalkingAnimation(direction);
    }

    void WalkingAnimation(Vector3 direction)
    {
        moveAnimator.SetFloat("MoveSpeed", direction.magnitude);
    }

}
