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
    private ParticleSystem ps;
    public GameObject bloodSplash;
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        rb.AddForce(tf.forward.x * speed, tf.forward.y * speed, tf.forward.z * speed,ForceMode.Impulse);
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider collision)
    {
      if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
      {
        collision.transform.gameObject.SendMessage("TakeDamage", 10);
        Instantiate(bloodSplash, tf.position, tf.rotation);
        Destroy(gameObject);
      }
      else if (collision.transform.gameObject.layer != LayerMask.NameToLayer("Bullets") && collision.transform.gameObject.layer != LayerMask.NameToLayer("Player"))
      {
        Destroy(gameObject);
      }
    }

}
