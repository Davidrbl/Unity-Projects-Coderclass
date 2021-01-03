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

  [SerializeField] private float nextTimeToShot = 0f;

  [SerializeField] private float timeBetweenShots = 0.2f;

  public float Ammo = 100;

  public float ammoInMag = 10f;

  private float magSize = 10f;

  private float BulletsPerShot = 4f;

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
      if (ammoInMag > 0 && canShoot)
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
    ammoInMag -= 1;
    UpdateAmmo();
  }
  public void UpdateAmmo()
  {
    if (canShoot)
    {
      ammoText.text = ammoInMag + "\t | " + Ammo;
    }
  }

  void Reload()
  {
    Ammo -= magSize - ammoInMag;
    if (Ammo < 0)
    {
      Ammo = 0;
    }
    if (Ammo >= magSize)
    {
      ammoInMag = magSize;
    }
    else
    {
      ammoInMag = Ammo;
    }
    UpdateAmmo();
  }
}
