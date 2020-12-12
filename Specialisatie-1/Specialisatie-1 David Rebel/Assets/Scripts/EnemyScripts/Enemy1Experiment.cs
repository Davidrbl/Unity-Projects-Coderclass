using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Experiment : MonoBehaviour
{
    private Transform tf;
    private float time = 0;
    public Transform playerTf;
    private float damping = 2f;
    private float speed = 1.5f;
    private float swooshSize = 2f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //tf.position = new Vector3(Mathf.Sin(time), 3, 0);
        Vector3 lookPos = playerTf.position - tf.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        rb.velocity = tf.right * Mathf.Sin(time) * swooshSize + new Vector3(0, 3, 0) + (tf.forward * speed);
        time += 0.05f;

    }
}
