using UnityEngine;
using UnityEngine.InputSystem;

public class TankControl : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f, rotationSpeed = 100.0f;

    [SerializeField] GameObject turret;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            transform.Translate(-Vector3.forward * movementSpeed * Time.fixedDeltaTime);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }

        if (Keyboard.current.jKey.isPressed)
        {
            turret.transform.Rotate(-Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }

        if (Keyboard.current.lKey.isPressed)
        {
            turret.transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
