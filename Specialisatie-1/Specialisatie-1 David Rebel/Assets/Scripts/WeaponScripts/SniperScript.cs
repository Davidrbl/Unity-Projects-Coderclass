﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{
  private Transform tf;

  private Camera cam;

  private float normalCamFOV = 60f;

  private float zoomCamFOV = 20f;

  public GameObject bulletPrefab;

  private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

  [SerializeField] private float nextTimeToShot = 0f;

  [SerializeField] private float timeBetweenShots = 0.2f;

  public float Ammo = 100;

  public float ammoInMag = 10f;

  private float magSize = 10f;

  private float BulletsPerShot = 4f;

  public bool canShoot;

  void Start()
  {
    tf = GetComponent<Transform>();
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();
  }

  /*void Update()
  {
    nextTimeToShot += Time.deltaTime;

    if (Input.GetButton("Fire1"))
    {
      if (nextTimeToShot >= timeBetweenShots)
      {
        Shoot();
        nextTimeToShot = 0f;
      }
    }
  }

  void Shoot()
      {
        Instantiate(bulletPrefab, tf.position, tf.rotation);
        ammoInMag -= 1;
      }

  void Reload()
  {

  }
  */
  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      StartScope();
    }
    if (Input.GetButtonUp("Fire1"))
    {
      StopScope();
      Shoot();
    }
  }

  void StartScope()
  {
    //Camera zoomt in
    cam.fieldOfView = zoomCamFOV;
  }
  void StopScope()
  {
    //Camera zoomt uit
    cam.fieldOfView = normalCamFOV;
  }
  void Shoot()
  {
    Instantiate(bulletPrefab, tf.position, tf.rotation);
    ammoInMag -= 1;
  }
}
