using UnityEngine;
using UnityEngine.InputSystem;

public class TankControl : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f, rotationSpeed = 100.0f, forwardValue, backwardValue, rightValue, leftValue, rightTurretValue, leftTurretValue;

    [SerializeField] GameObject turret;

    InputAction moveAction, turretRotateAction;

    Vector2 moveValue;
    float turretRotateValue;

    [SerializeField] int gamepadIndex;

    [SerializeField] InputActionMap playerActionMap;

    Rigidbody rbody;

    bool grounded = true;
    bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        
        if (Gamepad.all.Count > 0)
        {
            playerActionMap.devices = new InputDevice[] { Gamepad.all[gamepadIndex] };
            moveAction = playerActionMap.FindAction("Move");
            moveAction.Enable();

            turretRotateAction = playerActionMap.FindAction("TurretRotate");
            turretRotateAction.Enable();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Keyboard inputs
        //forwardValue = Keyboard.current.wKey.value;
        //backwardValue = Keyboard.current.sKey.value;
        //leftValue = Keyboard.current.aKey.value;
        //rightValue = Keyboard.current.dKey.value;
        //leftTurretValue = Keyboard.current.jKey.value;
        //rightTurretValue = Keyboard.current.lKey.value;

        // Gamepad inputs
        //if (Gamepad.all.Count > gamepadIndex)
        //{
        //    // Gampad Control
        //    forwardValue = Gamepad.all[gamepadIndex].leftStick.up.value;
        //    backwardValue = Gamepad.all[gamepadIndex].leftStick.down.value;
        //    rightValue = Gamepad.all[gamepadIndex].leftStick.right.value;
        //    leftValue = Gamepad.all[gamepadIndex].leftStick.left.value;
        //    rightTurretValue = Gamepad.all[gamepadIndex].rightStick.right.value;
        //    leftTurretValue = Gamepad.all[gamepadIndex].rightStick.left.value;
        //}

        //if (Keyboard.current.spaceKey.wasPressedThisFrame && grounded && !jump)
        //{
        //    jump = true;            
        //}

        moveValue = moveAction.ReadValue<Vector2>();
        turretRotateValue = turretRotateAction.ReadValue<float>();
    }

    void FixedUpdate()
    {
        // Hardcoded gamepad
        //transform.Translate(Vector3.forward * (forwardValue - backwardValue) * movementSpeed * Time.fixedDeltaTime);
        //transform.Rotate(Vector3.up, (rightValue - leftValue) * rotationSpeed * Time.fixedDeltaTime);
        //turret.transform.Rotate(Vector3.up, (rightTurretValue - leftTurretValue) * rotationSpeed * Time.fixedDeltaTime);

        transform.Translate(Vector3.forward * moveValue.y * movementSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up, moveValue.x * rotationSpeed * Time.fixedDeltaTime);
        turret.transform.Rotate(Vector3.up, turretRotateValue * rotationSpeed * Time.fixedDeltaTime);

        //if (jump)
        //{
        //    rbody.linearVelocity = Vector3.zero;
        //    rbody.AddRelativeForce(Vector3.up * 20.0f, ForceMode.Impulse);
        //    grounded = false;
        //    jump = false;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        grounded = true;
    }
}
