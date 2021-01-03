using UnityEngine;
using UnityEngine.UI;

public class ShotgunScript : MonoBehaviour
{
    private Transform tf;

    public GameObject bulletPrefab;

    public GameObject bulletImpulsePrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    public float Ammo = 100;

    public float ammoInMag = 10f;

    private float magSize = 10f;

    private float BulletsPerShot = 4f;

    public Text ammoText;

    public bool canShoot = false;

    void Start()
    {
      tf = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Update()
    {
      if (Input.GetButtonDown("Fire1") && canShoot)
      {
        if (ammoInMag >= BulletsPerShot)
        {
          for (int i = 0; i < BulletsPerShot; i++)
          {
            Shoot(i, (i == 0));
          }
        }
        else
        {
          for (int i = 0; i < ammoInMag; i++)
          {
            Shoot(i, (i == 0));
          }
        }
      }
      if (Input.GetKeyDown(KeyCode.R) && canShoot)
      {
        Reload();
      }

    }

    void Shoot(int spreadRadius, bool hasImpact)
        {
          if (!hasImpact)
          {
            Vector3 spread = Random.insideUnitSphere * spreadRadius;
            Instantiate(bulletPrefab, tf.position, tf.rotation * Quaternion.Euler(spread));
          }
          else
          {
            Instantiate(bulletImpulsePrefab, tf.position, tf.rotation);
            //Debug.Log("bla");
          }
          ammoInMag -= 1;
          UpdateAmmo();
        }
    public void UpdateAmmo()
    {
      if (canShoot)
      {
        ammoText.text = ammoInMag + "\t | \t" + Ammo;
      }
    }

    void Reload()
    {
      Ammo -= magSize - ammoInMag;
      if (Ammo < 0)
      {
        Ammo = 0;
      }
      if (Ammo >= magSize)
      {
        ammoInMag = magSize;
      }
      else
      {
        ammoInMag = Ammo;
      }
      UpdateAmmo();
    }
}
