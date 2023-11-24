using UnityEngine;

public class AbilitySpellT0 : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int numberOfBullets = 20;
    [SerializeField] private float cooldown = 0.1f;
    private float lastShot;

    private void Awake()
    {
        bullet = Resources.Load("Prefabs/Bullets/pBulletStaff0") as GameObject;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && Time.time - lastShot >= cooldown)
        {
            var badMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePosition = new Vector3(badMousePosition.x, badMousePosition.y, 0f);
            float deltaAngle = 360f / numberOfBullets;
            for(int i = 0; i < numberOfBullets; i++)
            {
                Quaternion angle = Quaternion.Euler(0, 0, i * deltaAngle);
                Instantiate(bullet, mousePosition, angle);
            }
            lastShot = Time.time;
        }
    }
}