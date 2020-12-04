using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
  public float Health = 30f;
  public void TakeDamage(float damage)
  {
    Health -= damage;

    //Debug.Log(gameObject.name + " took damage. Health = " + Health);

    if (Health <= 0)
    {
      Destroy(gameObject);
    }
  }
}
