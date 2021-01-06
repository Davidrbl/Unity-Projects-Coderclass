using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartDoorScript : MonoBehaviour
{
    public GameObject northDoor;
    public GameObject southDoor;

    private bool isInLevel = false;
    private bool isInFirstLevel;

    public void setNorthDoor(bool door)
    {
      Debug.Log("north door veranderd!");
      northDoor.SetActive(door);
    }

    public void setSouthDoor(bool door)
    {
      Debug.Log("south door veranderd!");
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

    void Start()
    {
      setNorthDoor(true);
    }
}
