using UnityEngine;
using UnityEngine.InputSystem;

public class StationaryTurret : MonoBehaviour
{
    [SerializeField] InputAction moveAction, fireAction;
    Vector2 moveValue;

    float rotationSpeed = 100.0f;
    float projectileVelocity = 10.0f;

    Vector3 angles;

    [SerializeField] GameObject guns, projectile, barrelRight, barrelLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();

        if (fireAction.WasPressedThisFrame())
        {
            Debug.Log("fire");
            GameObject instantiatedObject = Instantiate(projectile, barrelLeft.transform.position, barrelLeft.transform.rotation);
            instantiatedObject.GetComponent<Rigidbody>().linearVelocity = instantiatedObject.transform.forward * projectileVelocity;

            instantiatedObject = Instantiate(projectile, barrelRight.transform.position, barrelRight.transform.rotation);
            instantiatedObject.GetComponent<Rigidbody>().linearVelocity = instantiatedObject.transform.forward * projectileVelocity;
        }
    }

    private void FixedUpdate()
    {
        // Turret rotation
        transform.Rotate(Vector3.up, moveValue.x * rotationSpeed * Time.fixedDeltaTime);

        angles = transform.localRotation.eulerAngles;
        if (angles.y > 45 && angles.y < 180)
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
        }
        if (angles.y < 315 && angles.y > 180)
        {
            transform.localRotation = Quaternion.Euler(0, 315, 0);
        }

        // Guns rotation
        guns.transform.Rotate(Vector3.right, -moveValue.y * rotationSpeed * Time.fixedDeltaTime);

        angles = guns.transform.localRotation.eulerAngles;
        if (angles.x > 45 && angles.x < 180)
        {
            guns.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }
        if (angles.x < 315 && angles.x > 180)
        {
            guns.transform.localRotation = Quaternion.Euler(315, 0, 0);
        }
    }

    private void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();
    }
}
