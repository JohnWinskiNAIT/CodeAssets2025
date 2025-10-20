using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public float upwardsModifier = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Debug.Log("collider");
            Rigidbody rb = hit.GetComponentInParent<Rigidbody>();

            if (rb != null)
            {
                Debug.Log("explode");
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);

                Health health = rb.gameObject.GetComponentInParent<Health>();

                if (health != null)
                {
                    health.ApplyDamage(20);

                }
            }
        }
        Destroy(gameObject);
    }
}
