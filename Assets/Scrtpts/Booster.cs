using UnityEngine;

public class Booster : MonoBehaviour
{
    Rigidbody rbody;
    [SerializeField] float forceAmount;
    [SerializeField] Vector3 velocity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rbody != null)
        {
            rbody.AddForceAtPosition(transform.up * forceAmount * Time.fixedDeltaTime, transform.position);
        }
        velocity = rbody.angularVelocity;
    }
}
