using UnityEngine;
using UnityEngine.InputSystem;

public class TankControl : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f, rotationSpeed = 100.0f, forwardValue, backwardValue, rightValue, leftValue, rightTurretValue, leftTurretValue;


    [SerializeField] GameObject turret;

    [SerializeField] int gamepadIndex;

    Rigidbody rbody;

    bool grounded = true;
    bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        forwardValue = Keyboard.current.wKey.value;
        backwardValue = Keyboard.current.sKey.value;
        leftValue = Keyboard.current.aKey.value;
        rightValue = Keyboard.current.dKey.value;
        leftTurretValue = Keyboard.current.jKey.value;
        rightTurretValue = Keyboard.current.lKey.value;

        if (Gamepad.all.Count > gamepadIndex)
        {
            // Gampad Control
            forwardValue = Gamepad.all[gamepadIndex].leftStick.up.value;
            backwardValue = Gamepad.all[gamepadIndex].leftStick.down.value;
            rightValue = Gamepad.all[gamepadIndex].leftStick.right.value;
            leftValue = Gamepad.all[gamepadIndex].leftStick.left.value;
            rightTurretValue = Gamepad.all[gamepadIndex].rightStick.right.value;
            leftTurretValue = Gamepad.all[gamepadIndex].rightStick.left.value;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && grounded && !jump)
        {
            jump = true;            
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (forwardValue - backwardValue) * movementSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up, (rightValue - leftValue) * rotationSpeed * Time.fixedDeltaTime);
        turret.transform.Rotate(Vector3.up, (rightTurretValue - leftTurretValue) * rotationSpeed * Time.fixedDeltaTime);

        if (jump)
        {
            rbody.linearVelocity = Vector3.zero;
            rbody.AddRelativeForce(Vector3.up * 20.0f, ForceMode.Impulse);
            grounded = false;
            jump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        grounded = true;
    }
}
