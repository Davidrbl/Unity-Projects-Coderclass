using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Transform tf;

    public float speed;

    private float movementLimit = 2f;

    private float counterFactor = 1f;

    public float lookDirection;

    public GameObject PlayerHead;

    public float jumpVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         //Getting inpyut from Player
         float InputForward = Input.GetAxis("Vertical");
         float InputSide = Input.GetAxis("Horizontal");

         Vector3 moveDir = (transform.right * InputSide + transform.forward * InputForward) * speed;

         float speedMultiplier = Mathf.Abs(moveDir.magnitude / movementLimit - 1);
         speedMultiplier = Mathf.Clamp(speedMultiplier, 0, 1);

         rb.AddForce(new Vector3(moveDir.x, 0, moveDir.z) * speedMultiplier, ForceMode.Impulse);
         rb.AddForce(new Vector3(-rb.velocity.x, 0, -rb.velocity.z) * counterFactor);

         if (Input.GetKeyDown("space"))
         {
           Jump();
         }
    }

    void Jump()
    {
      rb.AddForce(0, jumpVelocity, 0, ForceMode.Impulse); //= new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
    }
}
