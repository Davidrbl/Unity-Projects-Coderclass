using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private float worth = 10f;
    public ScoreScript ss;
    void OnCollisionEnter()
    {
      ss.GetPoints(worth);
      Destroy(this.gameObject);

    }
}
