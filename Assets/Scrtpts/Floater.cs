using UnityEngine;

public class Floater : MonoBehaviour
{
    Rigidbody rbody;

    [SerializeField] float forceAmount = 50.0f;
    RaycastHit hit;
    float distance, maxDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        maxDistance = 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance))
        {
            float percentage = (maxDistance / (maxDistance - hit.distance));
            rbody.AddForce(Vector3.up * forceAmount * percentage * Time.fixedDeltaTime);
        }
    }
}
