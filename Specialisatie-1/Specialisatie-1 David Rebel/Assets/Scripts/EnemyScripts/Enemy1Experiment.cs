using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Experiment : MonoBehaviour
{
    private Transform tf;
    private float time = 0;
    public Transform playerTf;
    private float damping = 100f;
    private float speed = 5f;
    private float swooshSize = 5f;
    private Rigidbody rb;
    private float stayRange = 5f;
    private int isInRangeFactor = 0;
    private Vector3 prevVel = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        playerTf = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //tf.position = new Vector3(Mathf.Sin(time), 3, 0);
        Vector3 lookPos = playerTf.position - tf.position;
        if (lookPos.magnitude >= stayRange)
        {
          isInRangeFactor = 1;
        }
        else
        {
          isInRangeFactor = 0;
        }
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        Vector3 moveVel = tf.right * Mathf.Sin(time) * swooshSize + (tf.forward * speed * isInRangeFactor);
        Vector3 currVel = new Vector3(moveVel.x, 0, moveVel.z);
        rb.AddForce(currVel - prevVel, ForceMode.Impulse);
        prevVel = currVel;
        time += 0.05f;

    }
}
