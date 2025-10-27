using UnityEngine;

public class TopDownCam : MonoBehaviour
{
    [SerializeField] GameObject topDownPerspective;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = topDownPerspective.transform.position;
    }
}
