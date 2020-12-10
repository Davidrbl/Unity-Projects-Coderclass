using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionScript : MonoBehaviour
{
    public GameObject[] allWeaponPrefabs;
    private int currentGunIndex = 0;
    [SerializeField] private GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
      ChooseGun(allWeaponPrefabs[currentGunIndex]);
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.mouseScrollDelta.y < 0)
      {
        currentGunIndex -= 1;
        currentGunIndex = Mathf.Clamp(currentGunIndex, 0, 2);
        Debug.Log(currentGunIndex);
        ChooseGun(allWeaponPrefabs[currentGunIndex]);
      }
      else if (Input.mouseScrollDelta.y > 0)
      {
        currentGunIndex += 1;
        currentGunIndex = Mathf.Clamp(currentGunIndex, 0, 2);
        Debug.Log(currentGunIndex);
        ChooseGun(allWeaponPrefabs[currentGunIndex]);
      }
      //Debug.Log(Input.mouseScrollDelta.y);
    }

    void ChooseGun(GameObject gunObj)
    {
      currentGun.SetActive(false);
      gunObj.SetActive(true);
      currentGun = gunObj;
    }
}
