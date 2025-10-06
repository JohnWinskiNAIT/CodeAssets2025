using UnityEngine;
using UnityEngine.InputSystem;

public class ForceMovement : MonoBehaviour
{
    Rigidbody rbody;

    [SerializeField] float forceAmount, forceTurn;

    [SerializeField] InputAction moveAction, moveAction2;
    Vector2 moveValue, moveValue2;

    [SerializeField] GameObject leftPos, rightPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        moveAction.Enable();
        moveAction2.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        moveValue2 = moveAction2.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        //rbody.AddRelativeForce(Vector3.forward * moveValue.y * forceAmount * Time.fixedDeltaTime);

        //rbody.AddRelativeTorque(Vector3.up * moveValue.x * forceTurn * Time.fixedDeltaTime);

        rbody.AddForceAtPosition(leftPos.transform.forward * moveValue.y * forceAmount * Time.fixedDeltaTime, leftPos.transform.position);

        rbody.AddForceAtPosition(rightPos.transform.forward * moveValue2.y * forceAmount * Time.fixedDeltaTime, rightPos.transform.position);
    }
}
