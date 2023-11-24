using UnityEngine;

public class WeaponBow0 : MonoBehaviour
{
    public float cooldown = 0.3f;
    private float lastShot;

    public GameObject bullet;
    public PlayerTransforms playerTransforms;

    private float gapSize = 15f;

    private void Awake()
    {
        playerTransforms = gameObject.transform.GetComponentInParent<PlayerTransforms>();
        bullet = Resources.Load("Prefabs/Bullets/pBulletBow0") as GameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastShot >= cooldown)
        {
            var rot1 = playerTransforms.rotationQ * Quaternion.Euler(Vector3.forward * gapSize);
            var rot2 = playerTransforms.rotationQ * Quaternion.Euler(Vector3.forward * -gapSize);
            Instantiate(bullet, transform.position, playerTransforms.rotationQ);
            Instantiate(bullet, transform.position, rot1);
            Instantiate(bullet, transform.position, rot2);
            lastShot = Time.time;
        }
    }
}
