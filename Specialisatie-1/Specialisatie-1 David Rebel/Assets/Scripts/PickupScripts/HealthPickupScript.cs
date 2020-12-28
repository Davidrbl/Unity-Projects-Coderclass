using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    private float healAmmount = 30f;

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.name == "Player")
      {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(healAmmount);
        Destroy(gameObject);
      }
    }
}
