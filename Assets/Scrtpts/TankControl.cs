using UnityEngine;
using UnityEngine.InputSystem;

public class TankControl : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f, rotationSpeed = 100.0f, forwardValue, backwardValue, rightValue, leftValue, rightTurretValue, leftTurretValue;


    [SerializeField] GameObject turret;

    [SerializeField] int gamepadIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Keyboard Control
        //if (Keyboard.current.wKey.isPressed)
        //{
        //    transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
        //}

        //if (Keyboard.current.sKey.isPressed)
        //{
        //    transform.Translate(-Vector3.forward * movementSpeed * Time.fixedDeltaTime);
        //}

        //if (Keyboard.current.aKey.isPressed)
        //{
        //    transform.Rotate(-Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        //}

        //if (Keyboard.current.dKey.isPressed)
        //{
        //    transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        //}

        //if (Keyboard.current.jKey.isPressed)
        //{
        //    turret.transform.Rotate(-Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        //}

        //if (Keyboard.current.lKey.isPressed)
        //{
        //    turret.transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        //}

        if (Gamepad.all.Count > gamepadIndex)
        { 

            // Gampad Control
            forwardValue = Gamepad.all[gamepadIndex].leftStick.up.value;
            backwardValue = Gamepad.all[gamepadIndex].leftStick.down.value;
            rightValue = Gamepad.all[gamepadIndex].leftStick.right.value;
            leftValue = Gamepad.all[gamepadIndex].leftStick.left.value;
            rightTurretValue = Gamepad.all[gamepadIndex].rightStick.right.value;
            leftTurretValue = Gamepad.all[gamepadIndex].rightStick.left.value;

            transform.Translate(Vector3.forward * (forwardValue - backwardValue) * movementSpeed * Time.fixedDeltaTime);
            transform.Rotate(Vector3.up, (rightValue - leftValue) * rotationSpeed * Time.fixedDeltaTime);
            turret.transform.Rotate(Vector3.up, (rightTurretValue - leftTurretValue) * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
