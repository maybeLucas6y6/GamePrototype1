using UnityEngine;

public class WeaponStaff0 : MonoBehaviour
{
    public float cooldown = 0.1f;
    private float lastShot;

    public GameObject bullet;
    public PlayerTransforms playerTransforms;

    private void Awake()
    {
        playerTransforms = gameObject.transform.GetComponentInParent<PlayerTransforms>();
        bullet = Resources.Load("Prefabs/Bullets/pBulletStaff0") as GameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - lastShot >= cooldown)
        {
            var b1 = Instantiate(bullet, transform.position, playerTransforms.rotationQ);
            b1.SendMessage("SetSign", 1);
            var b2 = Instantiate(bullet, transform.position, playerTransforms.rotationQ);
            b2.SendMessage("SetSign", -1);
            lastShot = Time.time;
        }
    }
}
