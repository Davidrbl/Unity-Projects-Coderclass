using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGunScript : MonoBehaviour
{
    private Transform tf;

    public GameObject bulletPrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    [SerializeField] private float nextTimeToShot = 0f;

    [SerializeField] private float timeBetweenShots = 0.5f;

    public float Ammo = 100;

    public float ammoInMag = 10f;

    private float magSize = 10f;

    private float BulletsPerShot = 4f;

    public bool canShoot;

    void Start()
    {
      tf = GetComponent<Transform>();
    }

    void Update()
    {
      nextTimeToShot += Time.deltaTime;

      if (Input.GetButton("Fire1"))
      {
        if (nextTimeToShot >= timeBetweenShots)
          Shoot();
          Debug.Log("bla" + Time.deltaTime + "\t" + nextTimeToShot);
          nextTimeToShot = 0f;
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
}
