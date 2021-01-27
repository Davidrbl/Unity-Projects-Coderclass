using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartDoorScript : MonoBehaviour
{
    public GameObject northDoor;
    public GameObject southDoor;
    public GameObject lighting;

    private bool isInLevel = false;
    private bool isInFirstLevel;

    public void prepareExit(bool door)
    {
      northDoor.SetActive(door);
      lighting.SetActive(door);
    }

    public void setSouthDoor(bool door)
    {
      southDoor.SetActive(door);
    }

    void Update()
    {
      if (GameObject.Find("Player").GetComponent<Transform>().position.z > southDoor.GetComponent<Transform>().position.z && !isInLevel)
      {
        setSouthDoor(true);
        isInLevel = true;
      }
    }
}
