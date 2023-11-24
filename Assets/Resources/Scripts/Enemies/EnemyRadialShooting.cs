using UnityEngine;

public class EnemyRadialShooting : MonoBehaviour
{
    public EnemyBasicDetecting detect;

    public GameObject bullet;
    public int numberOfBullets;
    private Quaternion rotation;
    private float lastShot;
    public float cooldown;
    public float rotationSpeed;
    private float deltaRotate;
    public bool clockwise = false;

    private void Update()
    {
        if (!detect.isActive) return;

        Shoot();
    }

    private void Shoot()
    {
        if (Time.time - lastShot >= cooldown)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                rotation.eulerAngles = new Vector3(0, 0, (((float)i / (float)numberOfBullets) * 360) + deltaRotate / 1000);
                Instantiate(bullet, transform.position, rotation);
            }
            lastShot = Time.time;
        }

        if (clockwise)
        {
            deltaRotate -= rotationSpeed;
        }
        else
        {
            deltaRotate += rotationSpeed;
        }
    }
}
