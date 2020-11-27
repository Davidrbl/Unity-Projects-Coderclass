using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
      collider.gameObject.GetComponent<Transform>().position = new Vector3(0,0,0);
      collider.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
}
