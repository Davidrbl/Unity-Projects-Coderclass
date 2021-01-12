using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
  private float speed = 5f;
  private float lifeTime = 10f;
  private Transform tf;
  private Rigidbody rb;
  void Start()
  {
      tf = GetComponent<Transform>();
      rb = GetComponent<Rigidbody>();
      rb.AddForce(tf.forward.x * speed, tf.forward.y * speed, tf.forward.z * speed,ForceMode.Impulse);
      Destroy(gameObject, lifeTime);
  }

  void OnTriggerEnter(Collider collision)
  {
    if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
    {
      collision.transform.gameObject.SendMessage("ChangeHealth", -10);
      Debug.Log("damage!");
      Destroy(gameObject);
    }
    else if (collision.transform.gameObject.layer != LayerMask.NameToLayer("Bullets") && collision.transform.gameObject.layer != LayerMask.NameToLayer("Enemy"))
    {
      Destroy(gameObject);
    }
  }

}
