using UnityEngine;

public class EnemyBasicShooting : MonoBehaviour
{
    public EnemyBasicDetecting detect;

    public GameObject bullet0;
    public float cooldown;
    private float lastShot;

    private void Update()
    {
        if (!detect.isActive) return;

        Shoot();
    }

    private void Shoot()
    {
        if (Time.time - lastShot >= cooldown)
        {
            Instantiate(bullet0, transform.position, detect.rotation);
            lastShot = Time.time;
        }
    }
}