using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseScript : MonoBehaviour
{
    private float ImpulseStrenth = 50f;
    private float playerImpulseStrength = 500f;
    private float ImpulseRadius = 10f;
    public LayerMask lm;
    private Transform tf;
    // Start is called before the first frame update
    void Awake()
    {
      //Debug.Log("ha");
      tf = GetComponent<Transform>();
      int maxColliders = 10;
      Collider[] hitColliders = new Collider[maxColliders];
      int numColliders = Physics.OverlapSphereNonAlloc(tf.position, ImpulseRadius, hitColliders, lm);
      for (int i = 0; i < numColliders; i++)
      {
          //force adden aan alle gameObjects met rigidbodies
          Vector3 moveDir = tf.position - hitColliders[i].GetComponent<Transform>().position;
          Rigidbody objRb = hitColliders[i].GetComponent<Rigidbody>();
          if (objRb != null)
          {
            if (objRb.gameObject.name == "Player")
            {
              objRb.AddForce((-moveDir) * playerImpulseStrength);
            }
            else
            {
              objRb.AddForce((-moveDir) * ImpulseStrenth);
            }

          }

          //Debug.Log("\t" + moveDir + hitColliders[i]);
      }
      //Debug.Log("Impulse!");
    }
}
