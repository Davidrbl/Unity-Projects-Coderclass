﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class machineGunScript : MonoBehaviour
{
    private Transform tf;

    public GameObject bulletPrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    private float nextTimeToShot = 0f;

    private float timeBetweenShots = 0.2f;

    public int totalAmmo = 100;

    private int currentAmmo = 10;

    private int magSize = 10;

    public Text ammoText;

    public bool canShoot = false;

    void Start()
    {
      tf = GetComponent<Transform>();
    }

    void Update()
    {
      nextTimeToShot += Time.deltaTime;

      if (Input.GetButton("Fire1") && canShoot && currentAmmo > 0 && nextTimeToShot >= timeBetweenShots)
      {
        Shoot();
        nextTimeToShot = 0f;
      }
      
      if (Input.GetKeyDown(KeyCode.R) && canShoot)
      {
        Reload();
      }
    }

    void Shoot()
        {
          Instantiate(bulletPrefab, tf.position, tf.rotation);
          currentAmmo -= 1;
          totalAmmo -= 1;
          UpdateAmmo();
        }

    public void UpdateAmmo()
    {
      if (canShoot)
      {
        ammoText.text = currentAmmo + "\t | \t" + (totalAmmo - currentAmmo);
      }
    }

    void Reload()
    {
      if (totalAmmo >= magSize)
      {
        currentAmmo = magSize;
      }
      else
      {
        currentAmmo = totalAmmo;
      }

      UpdateAmmo();
    }
}
