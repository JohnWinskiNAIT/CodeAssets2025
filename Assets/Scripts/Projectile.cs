using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifetime, damage;

    [SerializeField] bool contactDestruct;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Destruct", lifetime);
    }

    void Destruct()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (contactDestruct)
        {
            Health health = collision.gameObject.GetComponentInParent<Health>();

            if (health != null)
            {
                health.ApplyDamage(damage);
            }
        }

        Destruct();
    }
}
