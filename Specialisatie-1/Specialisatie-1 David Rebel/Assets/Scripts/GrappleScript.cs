using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour
{
  private GrapplingGunScript ggs;
  private Transform tf;
  private Rigidbody rb;
  private bool hascollided = false;

  void Awake()
  {
    ggs = GameObject.Find("GrapplingGun").GetComponent<GrapplingGunScript>();
    tf = GetComponent<Transform>();
  }
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.AddForce(tf.forward * 50, ForceMode.Impulse);
  }
  void OnTriggerEnter(Collider collision)
  {
    if (!hascollided)
    {
      ggs.StartGrapple(this.gameObject);
      Debug.Log("kaboom!");
      rb.isKinematic = true;
      hascollided = true;
    }
  }
}
