using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction moveAction, rotateAction, fireAction, fireAction2;

    Vector2 moveValue, rotateValue;

    float movementSpeed, rotationSpeed;

    [SerializeField] GameObject weaponPivot;

    Vector3 angles;

    [SerializeField] GameObject firstPerson, thirdPerson, playerCam;
    bool firstPersonPerspective = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = 3.0f;
        rotationSpeed = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();

        transform.Rotate(Vector3.up, rotateValue.x * rotationSpeed * Time.fixedDeltaTime);

        weaponPivot.transform.Rotate(Vector3.right, -rotateValue.y * rotationSpeed * Time.fixedDeltaTime);

        angles = weaponPivot.transform.localEulerAngles;

        if (angles.x < 300 && angles.x > 180)
        {
            weaponPivot.transform.localRotation = Quaternion.Euler(300, 0, 0);
        }

        if (angles.x > 45 && angles.x < 180)
        {
            weaponPivot.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }

        if (fireAction.IsPressed())
        {
            BroadcastMessage("FireWeapon");
        }
        if (fireAction2.IsPressed())
        {
            BroadcastMessage("FireWeapon2");
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            firstPersonPerspective = !firstPersonPerspective;

            if (firstPersonPerspective)
            {
                playerCam.transform.localPosition = firstPerson.transform.localPosition;
            }
            else
            {
                playerCam.transform.localPosition = thirdPerson.transform.localPosition;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * movementSpeed * Time.fixedDeltaTime);
    }    

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
        fireAction.Enable();
        fireAction2.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        fireAction.Disable();
        fireAction2.Disable();
    }
}
