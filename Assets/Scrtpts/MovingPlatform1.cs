using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{
    float movementTime, movementSpeed, timeStamp;
    Rigidbody rbody;

    [SerializeField] Vector3 moveVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = 3.0f;
        movementTime = 5.0f;

        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > timeStamp + movementTime)
        {
            movementSpeed = -movementSpeed;
            timeStamp = Time.time;
        }
        rbody.linearVelocity = moveVector * movementSpeed * 100 * Time.fixedDeltaTime;
        //transform.Translate(Vector3.right * movementSpeed * Time.fixedDeltaTime);
    }
}
