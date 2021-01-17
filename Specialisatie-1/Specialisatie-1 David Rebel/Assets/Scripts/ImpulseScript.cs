﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseScript : MonoBehaviour
{
    private float ImpulseStrenth = 800f;
    private float ImpulseRadius = 10f;
    public LayerMask lm;
    private Transform tf;
    private ParticleSystem pf;
    // Start is called before the first frame update
    void Start()
    {
      //Debug.Log("ha");
      //GetComponent<ParticleSystem>().Play();
      tf = GetComponent<Transform>();
      int maxColliders = 10;
      Collider[] hitColliders = new Collider[maxColliders];
      int numColliders = Physics.OverlapSphereNonAlloc(tf.position, ImpulseRadius, hitColliders, lm);
      for (int i = 0; i < numColliders; i++)
      {
          //force adden aan alle gameObjects met rigidbodies
          Vector3 moveDir = hitColliders[i].GetComponent<Transform>().position - tf.position;
          //moveDir = new Vector3(1/moveDir.x, 1/moveDir.y, 1/moveDir.z);
          Rigidbody objRb = hitColliders[i].GetComponent<Rigidbody>();
          if (objRb != null)
          {
              objRb.AddForce(moveDir.normalized * ImpulseStrenth);
          }

          //Debug.Log("\t" + moveDir + hitColliders[i]);
      }
      Destroy(gameObject, 1f);
      //Debug.Log("Impulse!");
    }
}
