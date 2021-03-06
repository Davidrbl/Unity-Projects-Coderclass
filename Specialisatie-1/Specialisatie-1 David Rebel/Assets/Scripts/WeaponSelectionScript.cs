﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionScript : MonoBehaviour
{
    public GameObject[] allWeaponVisuals;
    private ShotgunScript sgs;
    private machineGunScript mgs;
    private SniperScript sns;
    public GameObject[] allWeaponPrefabs;
    [SerializeField] private int currentGunIndex = 0;
    public GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
      sgs = GameObject.Find("shotgun Variant").GetComponent<ShotgunScript>();
      mgs = GameObject.Find("machinegun").GetComponent<machineGunScript>();
      sns = GameObject.Find("sniper").GetComponent<SniperScript>();
      ChooseGun();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.mouseScrollDelta.y < 0)
      {
        currentGunIndex += 1;
        currentGunIndex = Mathf.Clamp(currentGunIndex, 0, 2);
        ChooseGun();
      }
      else if (Input.mouseScrollDelta.y > 0)
      {
        currentGunIndex -= 1;
        currentGunIndex = Mathf.Clamp(currentGunIndex, 0, 2);
        ChooseGun();
      }
    }

    void ChooseGun()
    {
      switch (currentGunIndex)
      {
        case 0:
          sgs.canShoot = true;
          mgs.canShoot = false;
          sns.canShoot = false;

          allWeaponVisuals[0].SetActive(true);
          allWeaponVisuals[1].SetActive(false);
          allWeaponVisuals[2].SetActive(false);

          sgs.SendMessage("UpdateAmmo");
          break;
        case 1:
          sgs.canShoot = false;
          mgs.canShoot = true;
          sns.canShoot = false;

          allWeaponVisuals[0].SetActive(false);
          allWeaponVisuals[1].SetActive(true);
          allWeaponVisuals[2].SetActive(false);

          mgs.SendMessage("UpdateAmmo");
          break;
        case 2:
          sgs.canShoot = false;
          mgs.canShoot = false;
          sns.canShoot = true;

          allWeaponVisuals[0].SetActive(false);
          allWeaponVisuals[1].SetActive(false);
          allWeaponVisuals[2].SetActive(true);

          sns.SendMessage("UpdateAmmo");
          break;
      }

      currentGun = allWeaponPrefabs[currentGunIndex];
    }
}
