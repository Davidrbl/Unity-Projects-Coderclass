using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    public float speed = 10f;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(tf.position + new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
          Instantiate(bulletPrefab, tf.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        tf.position = new Vector2(Mathf.Clamp(tf.position.x, -(float)8.5, (float)8.5), Mathf.Clamp(tf.position.y, -(float)4.5, (float)4.5));
    }

    public void Die()
    {
      Destroy(this.gameObject);
    }
    void OnCollisionEnter2D()
    {
      Debug.Log("HIT!");
    }
}
