using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARammoPickupScript : MonoBehaviour
{
  private float ammoAmmount = 30f;



  void Awake()
  {
    machineGunScript mgs = GameObject.Find("machinegun").GetComponent<machineGunScript>();
    Debug.Log(mgs);
  }
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name == "Player")
    {
      machineGunScript mgs = collision.transform.Find("Head").transform.Find("machinegun").GetComponent<machineGunScript>();
      mgs.Ammo += ammoAmmount;
      mgs.SendMessage("UpdateAmmo");
      Destroy(gameObject);
    }
  }
}
