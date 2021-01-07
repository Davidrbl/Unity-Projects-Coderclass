using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARammoPickupScript : MonoBehaviour
{
  private int ammoAmmount = 30;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Player")
    {
      //collision.gameObject.GetComponentInChildren(typeof(ShotgunScript)).Ammo += ammoAmmount;
      machineGunScript sgs = collision.transform.Find("Head").transform.Find("machinegun").GetComponent<machineGunScript>();
      sgs.totalAmmo += ammoAmmount;
      sgs.SendMessage("UpdateAmmo");
      Destroy(gameObject);
    }
  }
}
