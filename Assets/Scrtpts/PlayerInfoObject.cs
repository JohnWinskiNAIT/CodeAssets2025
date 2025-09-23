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

    public static string GetName()
    {
        return instance.playerName;
    }
    public static void SetName(string value)
    {
        instance.playerName = value;
    }
}
