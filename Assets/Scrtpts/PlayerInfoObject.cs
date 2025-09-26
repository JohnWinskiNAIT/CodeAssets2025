using UnityEngine;

public class PlayerInfoObject : MonoBehaviour
{
    public static PlayerInfoObject instance;

    [SerializeField] string playerName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public string GetName()
    {
        return playerName;
    }
    public void SetName(string value)
    {
        playerName = value;
    }
}
