using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public Transform target;
    public float rotSpeed = 20f;

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

        float alignment = Vector3.Dot(transform.forward, direction);

        if (alignment > 0.98f)
        {
            Debug.DrawLine(transform.position, target.position, Color.red);
        }
    }
}
