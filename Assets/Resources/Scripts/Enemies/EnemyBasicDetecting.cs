using UnityEngine;

public class EnemyBasicDetecting : MonoBehaviour
{
    public bool isActive = false;

    private GameObject target;

    public float detectionRange;
    public float activeRange;

    [HideInInspector] public Vector3 direction;
    [HideInInspector] public float angle;
    [HideInInspector] public Quaternion rotation;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(target == null)
        {
            isActive = false;
            return;
        }

        Activate();

        UpdateVars();
    }

    private void UpdateVars()
    {
        direction = target.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.Euler(0, 0, angle - 90f);
        direction.Normalize();
    }

    private void Activate()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= detectionRange)
        {
            isActive = true;
        }
        if (Vector3.Distance(transform.position, target.transform.position) > activeRange)
        {
            isActive = false;
        }
    }
}
