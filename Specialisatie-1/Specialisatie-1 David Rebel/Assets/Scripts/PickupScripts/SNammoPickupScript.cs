using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNammoPickupScript : MonoBehaviour
{
  private int ammoAmmount = 30;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Player")
    {
      SniperScript sgs = collision.transform.Find("Head").transform.Find("sniper").GetComponent<SniperScript>();
      sgs.totalAmmo += ammoAmmount;
      sgs.SendMessage("UpdateAmmo");
      Destroy(gameObject);
    }
  }
}
