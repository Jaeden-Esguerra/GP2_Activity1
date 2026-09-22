using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 0.5f;

    float progress = 0f;
    bool toB = true;

    void OnEnable()
    {
        Debug.Log(gameObject.name + " enabled");
    }

    void OnDisable()
    {
        Debug.Log(gameObject.name + " disabled");
    }

    void Update()
    {
        progress += Time.deltaTime * speed;
        if (progress >= 1f)
        {
            progress = 0f;
            toB = !toB;
        }

        Vector3 from = toB ? pointA.position : pointB.position;
        Vector3 to = toB ? pointB.position : pointA.position;
        transform.position = Vector3.Lerp(from, to, progress);
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        GameManager.Instance.addScore(10);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HazardZone"))
        {
            GameManager.Instance.removeScore(5);
        }
    }
}
