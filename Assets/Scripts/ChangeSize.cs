using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    [SerializeField] float lifetime;

    [SerializeField] bool contactDestruct;

    [SerializeField] bool bigger;

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
        if (contactDestruct && collision.transform.tag == "Modifiable")
        {
            if (!bigger)
            {
                collision.gameObject.transform.localScale *= 0.5f; 
            }
            else
            {
                collision.gameObject.transform.localScale *= 2.0f;
            }
        }

        Destruct();
    }
}
