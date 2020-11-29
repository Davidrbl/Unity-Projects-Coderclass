using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed = 70f;
    private float lifeTime = 5f;
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
      if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
      {
        collision.transform.gameObject.SendMessage("TakeDamage", 10);
      }
      else if (collision.transform.gameObject.layer != LayerMask.NameToLayer("Bullets"))
      {
        Destroy(gameObject);
      }
    }

}
