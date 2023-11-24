using UnityEngine;

public class PlayerTransforms : MonoBehaviour
{
    private new Camera camera;
    public float cameraRotationSpeed;
    public float speed;
    private Vector3 movement;

    [HideInInspector] public Quaternion rotationQ;
    [HideInInspector] public Vector3 rotationV;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        UpdateCameraRotation();

        MovementInput();
        ShootingInput();

        transform.position = Vector3.Lerp(transform.position, transform.position + movement, Time.deltaTime * speed);
    }

    private void MovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(x * camera.transform.right.x + y * camera.transform.up.x,
                               y * camera.transform.up.y + x * camera.transform.right.y).normalized;
    }

    private void UpdateCameraRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(cameraRotationSpeed * Time.deltaTime * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(cameraRotationSpeed * Time.deltaTime * Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void ShootingInput()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        rotationV = mousePosition - transform.position;
        float rotZ = Mathf.Atan2(rotationV.y, rotationV.x) * Mathf.Rad2Deg;
        rotationQ = Quaternion.Euler(0, 0, rotZ - 90f);
    }
}
