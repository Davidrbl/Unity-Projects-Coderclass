using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactScript : MonoBehaviour
{
  private float speed = 70f;
  private float lifeTime = 5f;
  public GameObject ImpactObj;
  private LayerMask layers;
  private Transform tf;
  private Rigidbody rb;
  private Vector3 dir;
  void Start()
  {
      tf = GetComponent<Transform>();
      rb = GetComponent<Rigidbody>();
      rb.AddForce(tf.forward.x * speed, tf.forward.y * speed, tf.forward.z * speed,ForceMode.Impulse);
      Destroy(gameObject, lifeTime);
  }

  void OnTriggerEnter(Collider collision)
  {
    /*
    if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    {
      collision.transform.gameObject.SendMessage("TakeDamage", 10);
    }
    else if (collision.transform.gameObject.layer != LayerMask.NameToLayer("Bullets"))
    {
      Destroy(gameObject);
    }
    */
    if (collision.transform.gameObject.layer != LayerMask.NameToLayer("Player") && collision.transform.gameObject.layer != LayerMask.NameToLayer("Bullets") && collision.transform.gameObject.layer != LayerMask.NameToLayer("Default"))
    {
      Instantiate(ImpactObj, tf);
      //Debug.Log(collision.transform.gameObject.layer);
      Destroy(gameObject);
    }
    //Debug.Log(collision.transform.gameObject.layer);
  }

}
