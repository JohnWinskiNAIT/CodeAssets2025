using UnityEngine;

public class Floater : MonoBehaviour
{
    Rigidbody rbody;

    [SerializeField] float forceAmount = 50.0f;
    RaycastHit hit;
    float maxDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponentInParent<Rigidbody>();
        maxDistance = 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance))
        {
            float percentage = ((maxDistance - hit.distance) / maxDistance);
            rbody.AddForceAtPosition(transform.up * forceAmount * percentage * Time.fixedDeltaTime, transform.position);
            rbody.linearDamping = 1;
        }
        else
        {
            rbody.linearDamping = 0;
        }
    }
}
