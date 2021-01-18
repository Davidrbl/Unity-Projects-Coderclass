using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGammoPickupScript : MonoBehaviour
{
  private int ammoAmmount = 24;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Player")
    {
      //collision.gameObject.GetComponentInChildren(typeof(ShotgunScript)).Ammo += ammoAmmount;
      ShotgunScript sgs = collision.transform.Find("Head").transform.Find("shotgun Variant").GetComponent<ShotgunScript>();
      sgs.totalAmmo += ammoAmmount;
      sgs.SendMessage("UpdateAmmo");
      Destroy(gameObject);
    }
  }
}
