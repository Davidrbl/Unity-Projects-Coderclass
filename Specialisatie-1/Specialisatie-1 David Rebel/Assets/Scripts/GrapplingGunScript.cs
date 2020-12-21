using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGunScript : MonoBehaviour
{
  private LineRenderer lr;
  public Rigidbody rb;
  public GameObject playerObj;
  private Transform tf;
  private SpringJoint joint;
  private Vector3 GrapplePoint;
  public LayerMask grappleLayer;
  public GameObject grapplePrefab;
  private GameObject grappleObj;
  private bool isGrappling = false;
  void Awake()
  {
    lr = GetComponent<LineRenderer>();
    tf = GetComponent<Transform>();
    joint = GetComponent<SpringJoint>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(1))
    {
      //Debug.Log("grapple!!");
      FireGrapple();
    }
    else if (Input.GetMouseButtonUp(1))
    {
      //Debug.Log("grapple Stopped!!!");
      StopGrapple();
    }

    tf.localRotation = Quaternion.Euler(0,0,0);
  }
  void LateUpdate()
  {
    if (isGrappling)
    {
      DrawRope();
    }
  }
  void FireGrapple()
  {
    Instantiate(grapplePrefab, tf.position, tf.rotation);
    grappleObj = GameObject.Find("Grapple(Clone)");
  }

  public void StartGrapple(GameObject grapple)
  {
    Vector3 grapplePos = grapple.GetComponent<Transform>().position;
    //Debug.Log("Start grapple at: " + grapplePos);
    joint = grapple.gameObject.AddComponent<SpringJoint>();
    //Debug.Log("Spring joint added!");
    //joint.autoConfigureConnectedAnchor = false;
    //joint.anchor = grapplePos;
    joint.connectedBody = rb;

    float distanceToJoint = Vector3.Distance(tf.position, grapplePos);

    joint.maxDistance = distanceToJoint * 0f;
    joint.minDistance = distanceToJoint * 0f;
    joint.spring = 30f;
    joint.damper = 0.2f;
    joint.massScale = 1f;
    joint.tolerance = 10f;

    lr.positionCount = 2;
    isGrappling = true;
  }

  void StopGrapple()
  {
    Destroy(grappleObj);
    Destroy(joint);
    //Debug.Log("Spring joint destroyed!");
    lr.positionCount = 0;
    isGrappling = false;
  }
  void DrawRope()
  {
    lr.SetPosition(0, tf.position);
    lr.SetPosition(1, grappleObj.GetComponent<Transform>().position);
  }

}
