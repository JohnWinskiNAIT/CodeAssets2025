using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    public void ChangeName(string name)
    {
        //PlayerInfo.SetName(name);
        
        PlayerInfoObject.instance.SetName(name);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToCreation()
    {
        SceneManager.LoadScene("Menu_Singleton");
    }
}
