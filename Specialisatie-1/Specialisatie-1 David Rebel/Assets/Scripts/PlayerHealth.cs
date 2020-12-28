using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    private float maxHealth = 100;

    private Transform tf;
    private Slider sl;
    //private int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        sl = GameObject.Find("Healthbar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
          ChangeHealth(10);
        }
        if (Input.GetKeyDown("p"))
        {
          ChangeHealth(-10);
        }

    }
    public void ChangeHealth(float changeHealth)
    {
      health += changeHealth;
      health = Mathf.Clamp(health, 0f, maxHealth);
      sl.value = health/maxHealth;
    }
}
