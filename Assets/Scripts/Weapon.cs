using UnityEngine;

public class Weapon : MonoBehaviour
{
    float fireRate, timeStamp;

    [SerializeField] GameObject barrelEnd, projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRate = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireWeapon()
    {
        if (Time.time > timeStamp + fireRate)
        {
            GameObject instantiatedObject = Instantiate(projectile, barrelEnd.transform.position, barrelEnd.transform.rotation);

            Rigidbody rbody = instantiatedObject.GetComponent<Rigidbody>();

            if (rbody != null)
            {
                rbody.linearVelocity = barrelEnd.transform.forward * 20;
                timeStamp = Time.time;
            }
        }
    }
}
