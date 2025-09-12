using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPanel : MonoBehaviour
{
    Animator myAnimator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            myAnimator.SetBool("Open", true);
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            myAnimator.SetBool("Open", false);
        }
    }
}
