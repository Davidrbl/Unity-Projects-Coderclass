using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform tf;
    public Transform playerTf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tf.position = playerTf.position + new Vector3(0, 10, 0);
    }
}
