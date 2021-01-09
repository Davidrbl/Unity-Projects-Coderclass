using UnityEngine;
using UnityEngine.UI;

public class ShotgunScript : MonoBehaviour
{
    private Transform tf;

    public GameObject bulletPrefab;

    public GameObject bulletImpulsePrefab;

    private Vector3 shootPoint = new Vector3(0, 0, (float)0.04);

    public int totalAmmo = 100;

    public int currentAmmo = 10;

    public int magSize = 10;

    private int BulletsPerShot = 4;

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
        if (currentAmmo >= BulletsPerShot)
        {
          for (int i = 0; i < BulletsPerShot; i++)
          {
            Shoot(i, (i == 0));
          }
        }
        else
        {
          for (int i = 0; i < currentAmmo; i++)
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
          }
          currentAmmo -= 1;
          totalAmmo -= 1;
          UpdateAmmo();
        }
    public void UpdateAmmo()
    {
      if (canShoot)
      {
        ammoText.text = currentAmmo + "\t | \t" + (totalAmmo - currentAmmo);
      }
    }

    void Reload()
    {
      if (totalAmmo >= magSize)
      {
        currentAmmo = magSize;
      }
      else
      {
        currentAmmo = totalAmmo;
      }

      UpdateAmmo();
    }
}
