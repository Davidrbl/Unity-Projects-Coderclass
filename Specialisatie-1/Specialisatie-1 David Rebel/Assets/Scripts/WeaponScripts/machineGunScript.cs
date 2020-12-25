using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class machineGunScript : MonoBehaviour
{
    private Transform tf;

    public GameObject bulletPrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    [SerializeField] private float nextTimeToShot = 0f;

    [SerializeField] private float timeBetweenShots = 0.2f;

    public float Ammo = 100;

    public float ammoInMag = 10f;

    private float magSize = 10f;

    private float BulletsPerShot = 4f;

    public Text ammoText;

    void Start()
    {
      tf = GetComponent<Transform>();
    }

    void Update()
    {
      nextTimeToShot += Time.deltaTime;

      if (Input.GetButton("Fire1"))
      {
        if (ammoInMag > 0)
        {
          if (nextTimeToShot >= timeBetweenShots)
          {
            Shoot();
            nextTimeToShot = 0f;
          }
        }
      }
      if (Input.GetKeyDown(KeyCode.R))
      {
        Reload();
      }
    }

    void Shoot()
        {
          Instantiate(bulletPrefab, tf.position, tf.rotation);
          ammoInMag -= 1;
          UpdateAmmo();
        }

    public void UpdateAmmo()
    {
      ammoText.text = ammoInMag + "\t | \t" + Ammo;
    }

    void Reload()
    {
      Ammo -= magSize - ammoInMag;
      ammoInMag = magSize;
      UpdateAmmo();
    }
}
