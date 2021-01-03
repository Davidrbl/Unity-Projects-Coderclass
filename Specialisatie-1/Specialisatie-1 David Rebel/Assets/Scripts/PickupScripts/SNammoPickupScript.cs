using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNammoPickupScript : MonoBehaviour
{
    private float ammoAmmount = 30f;

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.name == "Player")
      {
        SniperScript sns = collision.transform.Find("Head").transform.Find("sniper").GetComponent<SniperScript>();
        sns.Ammo += ammoAmmount;
        sns.SendMessage("UpdateAmmo");
        Destroy(gameObject);
      }
    }
}
