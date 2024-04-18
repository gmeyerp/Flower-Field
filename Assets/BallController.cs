using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    private Vector3 currentVelocity = Vector3.zero;
    [SerializeField] float smoothTime = 0.4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Input.acceleration != Vector3.zero)
        {
            dir = CalculateAcceleration(dir);
            MoveBall(dir);
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    private static Vector3 CalculateAcceleration(Vector3 dir)
    {
        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;
        dir.y = 0;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        return dir;
    }

    void MoveBall(Vector3 dir)
    {
        Vector3 targetVelocity = dir * speed;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, smoothTime);
    }
}
