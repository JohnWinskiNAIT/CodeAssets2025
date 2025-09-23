using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadCharacter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //nameText.text = PlayerInfo.GetName();
        nameText.text = PlayerInfoObject.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }
}
