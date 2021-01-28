using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform tf;
    private float speed = 0.1f;
    private float lifeSpan = 3f;
    private GameControllerScript gcs;
    // Start is called before the first frame update
    void Start()
    {
      tf = GetComponent<Transform>();
      Destroy(this.gameObject, lifeSpan);
      gcs = GameObject.Find("Game Controller").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tf.Translate(new Vector2(0, -speed));
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
      if (collider.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
      {
        Destroy(collider.collider.gameObject);
        Destroy(this.gameObject);
        gcs.GetPoint();
      }
      else if (collider.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
      {
        collider.gameObject.SendMessage("Die");
        Destroy(this.gameObject);
        gcs.playerDied();
      }
      Debug.Log("Collision met: " + collider.collider.gameObject.layer);
    }
}
