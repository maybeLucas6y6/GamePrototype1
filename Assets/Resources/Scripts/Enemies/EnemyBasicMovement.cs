using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{
    public EnemyBasicDetecting detect;

    public float speed = 3f;

    private void Update()
    {
        if (!detect.isActive)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, transform.position + detect.direction, Time.deltaTime * speed);
    }
}
