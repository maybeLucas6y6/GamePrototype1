using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    private new Camera camera;

    void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.rotation = camera.transform.rotation;
    }
}
