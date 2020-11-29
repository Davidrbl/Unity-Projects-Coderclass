using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int health = 100;

    private RectTransform tf;
    //private int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //health =

        if (Input.GetKeyDown("o"))
        {
          health -= 10;
        }
        if (Input.GetKeyDown("p"))
        {
          health += 10;
        }
        
    }
}
