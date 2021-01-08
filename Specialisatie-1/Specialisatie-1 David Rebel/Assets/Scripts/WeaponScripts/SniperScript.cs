using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperScript : MonoBehaviour
{
  private Transform tf;

  private Camera cam;

  private float normalCamFOV = 60f;

  private float zoomCamFOV = 20f;

  public GameObject bulletPrefab;

  private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

  public int totalAmmo = 30;

  public int currentAmmo = 3;

  private int magSize = 3;

  public Text ammoText;

  public bool canShoot = false;

  void Start()
  {
    tf = GetComponent<Transform>();
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();
  }

  void Update()
  {
    if (Input.GetButtonDown("Fire1") && canShoot)
    {
      StartScope();
    }
    if (Input.GetButtonUp("Fire1"))
    {
      StopScope();
      if (currentAmmo > 0 && canShoot)
      {
        Shoot();
      }
    }
    if (Input.GetKeyDown(KeyCode.R) && canShoot)
    {
      Reload();
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
    currentAmmo -= 1;
    totalAmmo -= 1;
    UpdateAmmo();
  }
  public void UpdateAmmo()
  {
    if (canShoot)
    {
      ammoText.text = currentAmmo + "\t | " + (totalAmmo - currentAmmo);
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
