using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseScript : MonoBehaviour
{
    private float ImpulseStrenth = 500f;
    private float ImpulseRadius = 500f;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
      tf = GetComponent<Transform>();
      int maxColliders = 10;
      Collider[] hitColliders = new Collider[maxColliders];
      int numColliders = Physics.OverlapSphereNonAlloc(tf.position, ImpulseRadius, hitColliders);
      for (int i = 0; i < numColliders; i++)
      {
          //force adden aan alle gameObjects met rigidbodies
          Vector3 moveDir = tf.position - hitColliders[i].GetComponent<Transform>().position;

          //hitColliders[i].GetComponent<Rigidbody>().AddForce((Vector3.one / moveDir) * ImpulseStrenth);
          Debug.Log(moveDir);
      }
      Debug.Log("Impulse!");
    }
}
