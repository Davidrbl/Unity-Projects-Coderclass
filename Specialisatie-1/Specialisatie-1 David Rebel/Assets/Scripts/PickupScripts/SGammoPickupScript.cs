using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGammoPickupScript : MonoBehaviour
{
  private float ammoAmmount = 30f;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Player")
    {
      //collision.gameObject.GetComponentInChildren(typeof(ShotgunScript)).Ammo += ammoAmmount;
      ShotgunScript sgs = collision.transform.Find("Head").transform.Find("shotgun Variant").GetComponent<ShotgunScript>();
      sgs.Ammo += ammoAmmount;
      sgs.SendMessage("UpdateAmmo");
      Destroy(gameObject);
    }
  }
}
