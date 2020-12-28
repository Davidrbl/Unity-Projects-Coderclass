using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARammoPickupScript : MonoBehaviour
{
  private float ammoAmmount = 30f;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Player")
    {
      collision.gameObject.GetComponent<machineGunScript>().Ammo += ammoAmmount;
      Destroy(gameObject);
    }
  }
}
