using UnityEngine;

public class WeaponKatana0 : MonoBehaviour
{
    public float cooldown = 0.2f;
    private float lastShot;

    public GameObject bullet;
    public PlayerTransforms playerTransforms;

    private void Awake()
    {
        playerTransforms = gameObject.transform.GetComponentInParent<PlayerTransforms>();
        bullet = Resources.Load("Prefabs/Bullets/pBulletKatana0") as GameObject;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && Time.time - lastShot >= cooldown)
        {
            Instantiate(bullet, transform.position, playerTransforms.rotationQ);
            lastShot = Time.time;
        }
    }
}
