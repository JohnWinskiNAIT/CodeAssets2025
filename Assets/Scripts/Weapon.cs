using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float fireRate, velocity; 
    float timeStamp;

    [SerializeField] GameObject barrelEnd, projectile, projectile2;


    void FireWeapon()
    {
        if (Time.time > timeStamp + fireRate)
        {
            GameObject instantiatedObject = Instantiate(projectile, barrelEnd.transform.position, barrelEnd.transform.rotation);

            Rigidbody rbody = instantiatedObject.GetComponent<Rigidbody>();

            Physics.IgnoreCollision(transform.GetComponentInChildren<Collider>(), instantiatedObject.GetComponentInChildren<Collider>());

            if (rbody != null)
            {
                rbody.linearVelocity = barrelEnd.transform.forward * velocity;
                timeStamp = Time.time;
            }
        }
    }

    void FireWeapon2()
    {
        if (Time.time > timeStamp + fireRate && projectile2 != null)
        {
            GameObject instantiatedObject = Instantiate(projectile2, barrelEnd.transform.position, barrelEnd.transform.rotation);

            Rigidbody rbody = instantiatedObject.GetComponent<Rigidbody>();

            Physics.IgnoreCollision(transform.GetComponentInChildren<Collider>(), instantiatedObject.GetComponentInChildren<Collider>());

            if (rbody != null)
            {
                rbody.linearVelocity = barrelEnd.transform.forward * velocity;
                timeStamp = Time.time;
            }
        }
    }
}
